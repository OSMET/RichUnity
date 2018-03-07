﻿using RichUnity.Spawners;
using RichUnity.TimeUtils.Timers;
using UnityEngine;

namespace RichUnity.TimeUtils {
    public class TimePoolableObject : ObjectPool.PoolableObject {
        public Timer PoolTimer;
        public float PoolTimerLimit;

        private void OnPoolTimerEnded() {
            gameObject.SetActive(false);
        }
        
        protected override void OnEnable() {
            PoolTimer.Start();
        }

        public virtual void Update() {
            PoolTimer.Update(Time.deltaTime);
            if (PoolTimer.Time > PoolTimerLimit) {
                OnPoolTimerEnded();
            }
        }
    }
}