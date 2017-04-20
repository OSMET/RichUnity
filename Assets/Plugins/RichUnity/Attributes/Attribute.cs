using System;
using Assets.Plugins.RichUnity.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Plugins.RichUnity.Attributes {
    public class Attribute : MonoBehaviour {
        public int MaxValue;
        public int StartValue;
        public int CurrentValue { get; private set; }
        public bool CanGrow;
        public bool Unsigned;
        public IntParameterEvent OnValueChangedEvent;
        public UnityEvent OnZeroOutEvent;
        public UnityEvent OnRessurectEvent;
        public bool Alive { get; private set; }

        public virtual void Awake() {
            if (MaxValue <= 0) {
                throw new ArgumentException("Max value can not be <= 0");
            }
            Alive = true;
            CurrentValue = StartValue;
            CheckBounds();
            CheckZeroOut();
        }

        private void CheckZeroOut() {
              if (Alive) {
                if (CurrentValue <= 0) {
                    OnZeroOutEvent.Invoke();
                    Alive = false;
                }
            } else {
                if (CurrentValue > 0) {
                    OnRessurectEvent.Invoke();
                    Alive = true;
                }
            }
        }

        private void CheckBounds() {
            if (CurrentValue < 0) {
                if (Unsigned) {
                    CurrentValue = 0;
                }
            } else if (CurrentValue > MaxValue) {
                if (!CanGrow) {
                    CurrentValue = MaxValue;
                } else {
                    MaxValue = CurrentValue;
                }
            }
        }

        public void AddValue(int value) {
            CurrentValue += value;

            CheckBounds();
            OnValueChangedEvent.Invoke(value);
            CheckZeroOut();
        }

        public int RemainingValue {
            get { return MaxValue - CurrentValue; }
        }

        public void ZeroOut() {
            AddValue(-CurrentValue);
        }
    }
}
