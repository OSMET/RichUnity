﻿using UnityEngine;
using UnityEngine.Events;

namespace Assets.Plugins.RichUnity.Lerps {
    public class Lerper : MonoBehaviour {
        public Lerp Lerp;

        public float LerpTime;

        private float currentTime;

        private bool began;
        private bool increasing;

        public bool EndValueReachedFromStart;

        public bool BeginOnAwake;

        public bool Looped;

        public UnityEvent IncreasingBeginEvent;
        public UnityEvent IncreasingEndEvent;

        public UnityEvent DecreasingBeginEvent;
        public UnityEvent DecreasingEndEvent;


        public void Start() {
           if (EndValueReachedFromStart) {
                currentTime = LerpTime;
                increasing = true;
                Lerp.ChangeValue(1f);
            } else {
                Lerp.ChangeValue(0f);
            }
            if (BeginOnAwake) {
                if (EndValueReachedFromStart) {
                    Decrease();
                } else {
                    Increase();
                }
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


        public void Update() {
            if (began) {
                float deltaTime = Time.deltaTime;
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