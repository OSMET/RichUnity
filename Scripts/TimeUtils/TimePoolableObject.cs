using RichUnity.Spawners;
using RichUnity.TimeUtils.Timers;
using UnityEngine;

namespace RichUnity.TimeUtils {
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
