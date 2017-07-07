using RichUnity.Spawners;
using RichUnity.Timers;
using UnityEngine;

namespace RichUnity.Poolables {
    public abstract class TimePoolableObject : ObjectPool.PoolableObject {

        public UnityEventTimer Timer;
        
        public override void OnEnable() {
            Timer.EndedEvent.AddListener(Timer_Ended);
            Timer.Start();
        }

        public abstract void Timer_Ended();

        public virtual void Update() {
            Timer.Update(Time.deltaTime);
        }
    }
}
