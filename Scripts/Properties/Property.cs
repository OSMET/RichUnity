using System;
using System.Runtime.Serialization;
using RichUnity.Attributes;
using RichUnity.Events;
using UnityEngine;
using UnityEngine.Events;

namespace RichUnity.Properties {
    [Serializable]
    public class Property {
        public int MaxValue = Int32.MaxValue;
        public int StartValue;

        #if UNITY_EDITOR
        [ReadOnly]
        [SerializeField]
        #endif
        private int currentValue;

        public int CurrentValue {
            get {
                CheckInit();
                return currentValue;
            }
            set {
                CheckInit();
                int oldCurrentValue = currentValue;
                currentValue = value;
                CheckBounds();
                DeltaValue = currentValue - oldCurrentValue;
                if (DeltaValue != 0 || AllowZeroDelta) {
                    OnValueChanged.Invoke(this);
                }
                CheckZeroOut();
            }
        }

        public bool CanGrow;
        public bool Unsigned;
        public bool AllowZeroDelta;
        [NonSerialized]
        public PropertyParameterEvent OnValueChanged = new PropertyParameterEvent();
        [NonSerialized]
        public UnityEvent OnZeroOut = new UnityEvent();
        [NonSerialized]
        public UnityEvent OnRessurected = new UnityEvent();
        public bool Alive { get; private set; }
        public int DeltaValue { get; private set; }
        private bool initialized;

        public Property() {
        }

        [OnDeserialized]
        public void OnDeserialized(StreamingContext context) {
            if (OnValueChanged == null) {
                OnValueChanged = new PropertyParameterEvent();
            }
            if (OnZeroOut == null) {
                OnZeroOut = new UnityEvent();
            }
            if (OnRessurected == null) {
                OnRessurected = new UnityEvent();
            }
        }

        public void Init() {
            if (!initialized) {
                if (MaxValue <= 0) {
                    throw new ArgumentException("Max value can not be <= 0");
                }
                Alive = true;
                currentValue = StartValue;
                CheckBounds();
                CheckZeroOut();
                initialized = true;
            }
        }

        private void CheckZeroOut() {
            if (Alive) {
                if (currentValue <= 0) {
                    OnZeroOut.Invoke();
                    Alive = false;
                }
            } else {
                if (currentValue > 0) {
                    OnRessurected.Invoke();
                    Alive = true;
                }
            }
        }

        private void CheckInit() {
            if (!initialized) {
                throw new InvalidOperationException("You should initialize property first. Just call Init().");
            }
        }

        private void CheckBounds() {
            if (currentValue < 0) {
                if (Unsigned) {
                    currentValue = 0;
                }
            } else if (currentValue > MaxValue) {
                if (!CanGrow) {
                    currentValue = MaxValue;
                } else {
                    MaxValue = currentValue;
                }
            }
        }

        public void AddValue(int value) {
            CurrentValue += value;
        }

        public int RemainingValue {
            get {
                return MaxValue - CurrentValue;
            }
        }

        public void ZeroOut() {
            AddValue(-CurrentValue);
        }

        public static implicit operator int(Property property) {
            return property.CurrentValue;
        }
    }
}
