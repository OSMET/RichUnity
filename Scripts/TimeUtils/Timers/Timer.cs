
namespace RichUnity.TimeUtils.Timers {
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
            AddTime(delta);
        }

        public virtual void AddTime(float time) {
            if (TimerOn) {
                Time += time;
                if (Time < 0f) {
                    Time = 0f;
                }
            }
        }
    }
}