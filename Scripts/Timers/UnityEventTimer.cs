using System;
using UnityEngine.Events;

namespace RichUnity.Timers {
    [Serializable]
    public class UnityEventTimer : LimitedTimer {
        public UnityEvent EndedEvent = new UnityEvent();

        public UnityEventTimer() {
            
        }

        public override void End() {
            EndedEvent.Invoke();
            base.End();
        }
        
        public void EndNoEvent() {
            base.End();
        }
    }
}
