using System;

namespace RichUnity.Timers {
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

        public override void Update(float delta) {
            base.Update(delta);
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

        public String RemainingTimeMMSS {
            get {
                int totalSecs = (int) RemainingTime + 1;
                //int hours = totalSecs / 3600;
                int minutes = (totalSecs % 3600) / 60;
                int seconds = totalSecs % 60;

                return String.Format("%02d:%02d", minutes, seconds);
            }
        }
    }
}