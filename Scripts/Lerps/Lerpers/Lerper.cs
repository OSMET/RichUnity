using UnityEngine;

namespace RichUnity.Lerps.Lerpers {
    public class Lerper : MonoBehaviour {
        public enum LerpModes {Normal, Loop, LoopPingPong}


        public Lerp Lerp;

        public float LerpTime;

        public float CurrentTime { get; private set; }

        public bool Began { get; private set; }
        public bool Increasing { get; private set; }

        public bool EndValueReachedFromStart;

        public bool BeginOnAwake;

        public bool UseUnscaledDeltaTime;

        public LerpModes LerpMode;

        private void Start() {
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
               CurrentTime = LerpTime;
               Increasing = true;
               Lerp.ChangeValue(1f);
           } else {
               CurrentTime = 0f;
               Increasing = false;
               Lerp.ChangeValue(0f);
           }
        }


        public void Increase() {
            Begin(true);
        }

        public void Decrease() {
            Begin(false);
        }

        public virtual void Begin(bool increasing) {
            Began = true;
            Increasing = increasing;
        }

        protected virtual float DeltaTime {
            get {
                return Time.deltaTime;
            }
        }

        public virtual void End() {
            Began = false;
            if (Increasing) {
                if (LerpMode == LerpModes.Loop) {
                    Reset();
                    Increase();
                } else if (LerpMode == LerpModes.LoopPingPong) {
                    Decrease();
                }
            } else {
                if (LerpMode == LerpModes.Loop) {
                    Reset();
                    Decrease();
                } else if (LerpMode == LerpModes.LoopPingPong) {
                    Increase();
                }
            }
        }

        public void Update() {
            if (Began) {
                float deltaTime = UseUnscaledDeltaTime ? Time.unscaledDeltaTime : DeltaTime;
                if (Increasing) {
                    CurrentTime += deltaTime;
                    if (CurrentTime >= LerpTime) {
                        CurrentTime = LerpTime;
                        End();
                    }
                } else {
                    CurrentTime -= deltaTime;
                    if (CurrentTime <= 0) {
                        CurrentTime = 0;
                        End();
                    }
                }
                Lerp.ChangeValue(CurrentTime / LerpTime);
            }
        }
    }
}