using System;
using UnityEngine.Events;

namespace Assets.Plugins.RichUnity.Timers {
    [Serializable]
    public class UnityEventTimer : LimitedTimer {
        public UnityEvent TimerEndedEvent;

        public UnityEventTimer() {
            
        }

        public override void End() {
            TimerEndedEvent.Invoke();
            base.End();
        }
    }
}
