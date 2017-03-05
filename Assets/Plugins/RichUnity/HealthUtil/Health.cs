using UnityEngine;

namespace Assets.Plugins.RichUnity.HealthUtil {
    public abstract class Health : MonoBehaviour {

        public int MaxHealth;
        public int CurrentHealth { get; private set; }

        public virtual void Awake() {
            CurrentHealth = MaxHealth;
        }

        public void AddHealth(int health) {
            CurrentHealth += health;
            OnHealthAdded(health);
            if (CurrentHealth > MaxHealth) {
                CurrentHealth = MaxHealth;
            } else if (CurrentHealth <= 0) {
                OnDeath();
            }
        }

        public int RemainingHealth {
            get { return MaxHealth - CurrentHealth; }
        }

        public void Die() {
            AddHealth(-CurrentHealth);
        }

        public bool IsAlive {
            get { return CurrentHealth > 0; }
        }

        public virtual void OnHealthAdded(int health) {   
        }
        public virtual void OnDeath() {
        }
    }
}
