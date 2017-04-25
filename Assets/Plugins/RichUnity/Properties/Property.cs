﻿using System;
using System.Diagnostics;
using Assets.Plugins.RichUnity.Events;
using UnityEngine.Events;

namespace Assets.Plugins.RichUnity.Properties {
    [Serializable]
    public class Property {
        public int MaxValue = 1;
        public int StartValue;

        private int currentValue;

        public int CurrentValue {
            get {
                return currentValue;
            }
            set {
                currentValue = value;
                CheckBounds();
                OnValueChangedEvent.Invoke(value);
                CheckZeroOut();
            }
        }

        public bool CanGrow;
        public bool Unsigned;
        public IntParameterEvent OnValueChangedEvent = new IntParameterEvent();
        public UnityEvent OnZeroOutEvent = new UnityEvent();
        public UnityEvent OnRessurectEvent = new UnityEvent();
        public bool Alive { get; private set; }

        public Property() {
        }

        public void Init() {
            if (MaxValue <= 0) {
                throw new ArgumentException("Max value can not be <= 0");
            }
            Alive = true;
            currentValue = StartValue;
            CheckBounds();
            CheckZeroOut();
        }

        private void CheckZeroOut() {
              if (Alive) {
                if (currentValue <= 0) {
                    OnZeroOutEvent.Invoke();
                    Alive = false;
                }
            } else {
                if (currentValue > 0) {
                    OnRessurectEvent.Invoke();
                    Alive = true;
                }
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
            get { return MaxValue - CurrentValue; }
        }

        public void ZeroOut() {
            AddValue(-CurrentValue);
        }

        public static implicit operator int(Property property) {
            return property.CurrentValue;
        }
    }
}