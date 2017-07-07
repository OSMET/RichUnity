using UnityEngine.Events;

namespace RichUnity.Timers {
    public class UnityEventTimersBundle<K> : TimersBundle<K, UnityEventTimer> {
        /// <summary>
        /// Author: Igor Ponomaryov
        /// </summary>
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