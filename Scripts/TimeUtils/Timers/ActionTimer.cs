using System;
using UnityEngine.Events;

namespace RichUnity.TimeUtils.Timers
{
    [Serializable]
    public class ActionTimer : LimitedTimer
    {
        public UnityAction OnStop;

        public ActionTimer()
        {
        }
        
        public ActionTimer(UnityAction onStop)
        {
            OnStop = onStop;
        }

        public override void Stop()
        {
            if (OnStop != null)
            {
                OnStop.Invoke();
            }
            base.Stop();
        }

        public void StopNoEvent()
        {
            base.Stop();
        }
    }
}