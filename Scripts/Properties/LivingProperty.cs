using System;
using System.Runtime.Serialization;
using RichUnity.Events;
using UnityEngine.Events;

namespace RichUnity.Properties
{
    [Serializable]
    public class LivingProperty : Property
    {
        
        public bool Alive { get; private set; }

        [NonSerialized] 
        public PropertyParameterEvent OnDead = new PropertyParameterEvent();
        [NonSerialized] 
        public PropertyParameterEvent OnRessurected = new PropertyParameterEvent();

        public int DeathValue;
        
        [OnDeserialized]
        public override void OnDeserialized(StreamingContext context) 
        {
            base.OnDeserialized(context);
            if (OnDead == null)
            {
                OnDead = new PropertyParameterEvent();
            }
            if (OnRessurected == null) 
            {
                OnRessurected = new PropertyParameterEvent();
            }
        }
        
        public override int Value {
            get 
            {
                return base.Value;
            }
            set
            {
                base.Value = value;
                CheckDeath();
            }
        }
        
        
        private void CheckDeath() 
        {
            if (Alive) 
            {
                if (Value <= DeathValue) 
                {
                    OnDead.Invoke(this);
                    Alive = false;
                }
            } 
            else 
            {
                if (Value > DeathValue) 
                {
                    OnRessurected.Invoke(this);
                    Alive = true;
                }
            }
        }
        
        public void Die() 
        {
            AddValue(-Value);
        }

        public int RemainingUpValue
        {
            get 
            {
                return MaxValue - Value - DeathValue;
            }
        }

    }
}
