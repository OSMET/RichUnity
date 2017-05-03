using System.Collections.Generic;

namespace Assets.Plugins.RichUnity.Timers {
    /// <summary>
    /// Author: Igor Ponomaryov, Evgeny Osmet
    /// </summary>
    public class TimersBundle<K, T> where T : Timer {

        private readonly Dictionary<K, T> timers = new Dictionary<K, T>();

        private readonly Queue<K> removeQueue = new Queue<K>();

        public void AddTimer(K key, T timer) {
            timers.Add(key, timer);
        }

        public T this[K key] {
            get { return timers[key]; }
        }

        public void RemoveTimer(K key) {
            removeQueue.Enqueue(key);
        }

        private void RemoveTimers() {
            while(removeQueue.Count > 0) {
                timers.Remove (removeQueue.Dequeue ());
            }
        }

        public void UpdateTimers(float deltaTime) {
            foreach (var timer in timers.Values) {
                timer.Update(deltaTime);
            }
            RemoveTimers();
        }
    }
}
