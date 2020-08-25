using System;
using UnityEngine.Events;

namespace RichUnity.TimeUtils.Timers
{
    [Serializable]
    public class EventTimer : LimitedTimer
    {
        public readonly UnityEvent OnStop = new UnityEvent();

        public EventTimer()
        {
        }

        public override void Stop()
        {
            OnStop.Invoke();
            base.Stop();
        }

        public void StopNoEvent()
        {
            base.Stop();
        }
    }
}