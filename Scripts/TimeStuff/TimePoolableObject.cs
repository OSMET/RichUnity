using RichUnity.Spawners;
using RichUnity.TimeStuff.Timers;
using UnityEngine;

namespace RichUnity.TimeStuff {
    public abstract class TimePoolableObject : ObjectPool.PoolableObject {

        public EventTimer Timer;
        
        protected override void OnEnable() {
            Timer.Start();
        }

        public virtual void Update() {
            Timer.Update(Time.deltaTime);
        }
    }
}
