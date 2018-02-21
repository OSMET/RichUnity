using System.Collections.Generic;

namespace RichUnity.TimeUtils.Timers {
    /// <summary>
    /// Author: Igor Ponomaryov, Evgeny Osmet
    /// </summary>
    public class TimerBundle<TKey, T> where T : Timer {

        private readonly Dictionary<TKey, T> timers = new Dictionary<TKey, T>();

        public Dictionary<TKey, T> Timers {
            get { return timers; }
        }

        private readonly Queue<TKey> removeQueue = new Queue<TKey>();

        public void AddTimer(TKey key, T timer) {
            timers.Add(key, timer);
        }

        public T this[TKey key] {
            get { return timers[key]; }
        }

        public void RemoveTimer(TKey key) {
            removeQueue.Enqueue(key);
        }

        private void RemoveTimers() {
            while(removeQueue.Count > 0) {
                timers.Remove (removeQueue.Dequeue ());
            }
        }

        public void UpdateTimers(float deltaTime) {
            foreach (var timer in timers.Values) {
                if (timer.TimerOn) {
                    timer.Update(deltaTime);
                }
            }
            RemoveTimers();
        }

        public void RemoveAll() {
            removeQueue.Clear();
            foreach (var timerKey in timers.Keys) {
                RemoveTimer(timerKey);
            }
        }
    }
}
