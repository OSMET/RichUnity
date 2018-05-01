using System;
using System.Runtime.Serialization;
using UnityEngine.Events;

namespace RichUnity.Properties
{
    [Serializable]
    public class LivingProperty : Property
    {
        
        public bool Alive { get; private set; }

        [NonSerialized] 
        public UnityEvent OnDead = new UnityEvent();
        [NonSerialized] 
        public UnityEvent OnRessurected = new UnityEvent();

        public int DeathValue;
        
        [OnDeserialized]
        public override void OnDeserialized(StreamingContext context) 
        {
            base.OnDeserialized(context);
            if (OnDead == null)
            {
                OnDead = new UnityEvent();
            }
            if (OnRessurected == null) 
            {
                OnRessurected = new UnityEvent();
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
                    OnDead.Invoke();
                    Alive = false;
                }
            } 
            else 
            {
                if (Value > DeathValue) 
                {
                    OnRessurected.Invoke();
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
