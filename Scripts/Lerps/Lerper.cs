using UnityEngine;
using UnityEngine.Events;

namespace RichUnity.Lerps {
    public class Lerper : MonoBehaviour {
        public Lerp Lerp;

        public float LerpTime;

        private float currentTime;

        private bool began;
        private bool increasing;

        public bool EndValueReachedFromStart;

        public bool BeginOnAwake;

        public bool Looped;
        public bool UseUnscaledDeltaTime;

        public UnityEvent IncreasingBeginEvent;
        public UnityEvent IncreasingEndEvent;

        public UnityEvent DecreasingBeginEvent;
        public UnityEvent DecreasingEndEvent;



        public void Start() {
            Reset();
            if (BeginOnAwake) {
                if (EndValueReachedFromStart) {
                    Decrease();
                } else {
                    Increase();
                }
            }
        }

        public void Reset() {
           if (EndValueReachedFromStart) {
               currentTime = LerpTime;
               increasing = true;
               Lerp.ChangeValue(1f);
           } else {
               currentTime = 0f;
               Lerp.ChangeValue(0f);
           }
        }

        public void Increase() {
            Begin(true);
        }

        public void Decrease() {
            Begin(false);
        }

        private void Begin(bool increasing) {
            if (increasing) {
                if (!this.increasing) {
                    IncreasingBeginEvent.Invoke();
                }
            } else {
                if (this.increasing) {
                    DecreasingBeginEvent.Invoke();
                }
            }
            began = true;
            this.increasing = increasing;
        }

        protected virtual float DeltaTime {
            get {
                return UseUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;
            }
        }

        public void Update() {
            if (began) {
                float deltaTime = DeltaTime;
                if (increasing) {
                    currentTime += deltaTime;
                    if (currentTime >= LerpTime) {
                        currentTime = LerpTime;
                        began = false;
                        IncreasingEndEvent.Invoke();
                        if (Looped) {
                            Decrease();
                        }
                    }
                } else {
                    currentTime -= deltaTime;
                    if (currentTime <= 0) {
                        currentTime = 0;
                        began = false;
                        DecreasingEndEvent.Invoke();
                        if (Looped) {
                            Increase();
                        }
                    }
                }
                Lerp.ChangeValue(currentTime / LerpTime);
            }
        }
    }
}