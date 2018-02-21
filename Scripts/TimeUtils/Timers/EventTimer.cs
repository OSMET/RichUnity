using System;
using UnityEngine.Events;

namespace RichUnity.TimeUtils.Timers {
    [Serializable]
    public class EventTimer : LimitedTimer {
        public UnityEvent OnEnded = new UnityEvent();

        public EventTimer() {
        }

        public override void End() {
            OnEnded.Invoke();
            base.End();
        }
        
        public void EndNoEvent() {
            base.End();
        }
    }
}
