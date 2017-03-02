using System;

namespace Assets.Plugins.RichUnity.Timers {
    [Serializable]
    public class EventTimer : LimitedTimer {
        public event EventHandler Ended;

        public EventTimer() {
            
        }

        public override void End() {
            if (Ended != null) {
                Ended(this, EventArgs.Empty);
            }
            base.End();
        }
    }
}
