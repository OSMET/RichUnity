using System;

namespace RichUnity.TimeStuff.Timers {
    [Serializable]
    public class LimitedTimer : Timer {
        public float TimeLimit;

        public bool Looped { get; set; }

        public LimitedTimer() {
            
        }

        public float CompletedPercent {
            get {
                return Time / TimeLimit;
            }
        }
        
        public float RemainingPercent {
            get {
                return RemainingTime / TimeLimit;
            }
        }

        public float RemainingTime {
            get {
                return TimeLimit - Time;
            }
        }

        public override void AddTime(float time) {
            base.AddTime(time);
            if (TimerOn && Time >= TimeLimit) {
                End();
            }
        }

        public override void End() {
            if (Looped) {
                Start();
            } else {
                base.End();
            }
        }

        public override void Resume() {
            if (Time >= TimeLimit) {
                Start();
            } else {
                base.Resume();
            }
        }
    }
}