
namespace RichUnity.Timers {
    public class Timer {
        public float Time { get; private set; }
        public bool TimerOn { get; private set; }

        public Timer() {
        }

        public virtual void Start() {
            TimerOn = true;
            Time = 0.0f;
        }
        
        public virtual void End() {
            TimerOn = false;
        }

        public virtual void Resume() {
            TimerOn = true;
        }

        public virtual void Update(float delta) {
            if (TimerOn) {
                Time += delta;
            }
        }
    }
}