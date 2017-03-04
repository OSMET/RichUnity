using System;
using Assets.Plugins.RichUnity.Spawners;
using Assets.Plugins.RichUnity.Timers;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Poolables {
    public abstract class TimePoolableObject : ObjectPool.PoolableObject {

        public EventTimer Timer;
        
        public override void OnEnable() {
            Timer.Ended += Timer_Ended;
            Timer.Start();
        }

        public abstract void Timer_Ended(object sender, EventArgs e);

        public virtual void Update() {
            Timer.Update(Time.deltaTime);
        }
    }
}
