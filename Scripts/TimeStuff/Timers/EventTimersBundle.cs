using System.Linq;
using UnityEngine.Events;

namespace RichUnity.TimeStuff.Timers {
    public class EventTimersBundle<K> : TimersBundle<K, EventTimer> {
        /// <summary>
        /// Author: Igor Ponomaryov
        /// </summary>
        public void InstantiateTimer(K key, bool looped, float timeLimit, bool start, UnityAction call = null) {
            var timer = new EventTimer {
                Looped = looped,
                TimeLimit = timeLimit
            };
            if (call != null) {
                timer.OnEnded.AddListener(call);
            }
            AddTimer(key, timer);
            if (start) {
                timer.Start();
            }
        }

        public void PauseAll() {
            foreach (var key in Timers.Keys) {
                PauseTimer(key);
            }

        }

        public void ResumeAll() {
            foreach (var key in Timers.Keys) {
                ResumeTimer(key);
            }
        }
        public void ResumeAllExcept(params K[] keys) {
            foreach (var key in Timers.Keys) {
                if(!keys.Contains(key))
                    ResumeTimer(key);
            }
        }

        public void PauseTimer(K key) {
            var timer = base[key];
            timer.Looped = false;
            timer.EndNoEvent();
        }

        public void ResumeTimer(K key, bool looped = true) {
            var timer = base[key];
            timer.Looped = looped;
            timer.Resume();
        }
    }
}