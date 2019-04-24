using System;
using System.Runtime.Serialization;
#if UNITY_EDITOR
using RichUnity.Attributes;
#endif
using RichUnity.Events;
using UnityEngine;
using UnityEngine.Events;

namespace RichUnity.Properties
{
    [Serializable]
    public class Property
    {
        public int MaxValue = Int32.MaxValue;
        public int MinValue = Int32.MinValue;

#if UNITY_EDITOR
        [ReadOnly]
#endif
        [SerializeField]
        private int value;

        public virtual int Value
        {
            get
            {
                CheckBounds();
                return value;
            }
            set
            {
                int oldValue = this.value;
                this.value = value;
                CheckBounds();
                DeltaValue = this.value - oldValue;
                if (DeltaValue != 0 || AllowZeroDelta)
                {
                    OnValueChanged.Invoke(this);
                }
            }
        }

        public bool CanGrowUp;
        public bool CanGrowDown;

        public bool AllowZeroDelta;

        [NonSerialized] 
        public PropertyParameterEvent OnValueChanged = new PropertyParameterEvent();

        public int DeltaValue { get; private set; }

        public Property()
        {
        }

        [OnDeserialized]
        public virtual void OnDeserialized(StreamingContext context)
        {
            if (OnValueChanged == null)
            {
                OnValueChanged = new PropertyParameterEvent();
            }
        }

        private void CheckBounds()
        {
            if (value < MinValue)
            {
                if (!CanGrowDown)
                {
                    value = MinValue;
                }
                else
                {
                    MinValue = value;
                }
            }
            else if (value > MaxValue)
            {
                if (!CanGrowUp)
                {
                    value = MaxValue;
                }
                else
                {
                    MaxValue = value;
                }
            }
        }

        public void AddValue(int value)
        {
            Value += value;
        }


        public static implicit operator int(Property property)
        {
            return property.Value;
        }
    }
}