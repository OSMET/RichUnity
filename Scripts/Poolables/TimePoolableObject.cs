using RichUnity.Spawners;
using RichUnity.Timers;
using UnityEngine;

namespace RichUnity.Poolables {
    public abstract class TimePoolableObject : ObjectPool.PoolableObject {

        public UnityEventTimer Timer;
        
        protected override void OnEnable() {
            Timer.Start();
        }

        public virtual void Update() {
            Timer.Update(Time.deltaTime);
        }
    }
}
