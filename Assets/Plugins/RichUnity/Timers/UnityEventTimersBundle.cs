﻿using UnityEngine.Events;

namespace Assets.Plugins.RichUnity.Timers {
    public class UnityEventTimersBundle<K> : TimersBundle<K, UnityEventTimer> {
        public void InstantiateTimer(K key, bool looped, float timeLimit, bool start, UnityAction call = null) {
            var timer = new UnityEventTimer() {
                Looped = looped,
                TimeLimit = timeLimit
            };
            if (call != null) {
                timer.EndedEvent.AddListener(call);
            }
            AddTimer(key, timer);
            if (start) {
                timer.Start();
            }
        }
    }
}