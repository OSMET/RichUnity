using System.Linq;
using UnityEngine.Events;

namespace RichUnity.TimeUtils.Timers
{
    public class EventTimersBundle<TKey> : TimerBundle<TKey, EventTimer>
    {
        /// <summary>
        /// Author: Igor Ponomaryov
        /// </summary>
        public void InstantiateTimer(TKey key, bool looped, float timeLimit, bool start, UnityAction call = null)
        {
            var timer = new EventTimer
            {
                Looped = looped,
                TimeLimit = timeLimit
            };
            if (call != null)
            {
                timer.OnStop.AddListener(call);
            }

            AddTimer(key, timer);
            if (start)
            {
                timer.Start();
            }
        }

        public void PauseAll()
        {
            foreach (var key in Timers.Keys)
            {
                PauseTimer(key);
            }
        }

        public void ResumeAll()
        {
            foreach (var key in Timers.Keys)
            {
                ResumeTimer(key);
            }
        }

        public void ResumeAllExcept(params TKey[] keys)
        {
            foreach (var key in Timers.Keys)
            {
                if (!keys.Contains(key))
                    ResumeTimer(key);
            }
        }

        public void PauseTimer(TKey key)
        {
            var timer = base[key];
            timer.Looped = false;
            timer.StopNoEvent();
        }

        public void ResumeTimer(TKey key, bool looped = true)
        {
            var timer = base[key];
            timer.Looped = looped;
            timer.Resume();
        }
    }
}