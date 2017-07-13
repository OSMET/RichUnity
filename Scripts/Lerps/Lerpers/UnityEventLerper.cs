using UnityEngine;
using UnityEngine.Events;

namespace RichUnity.Lerps.Lerpers {
    public class UnityEventLerper : Lerper {
        public UnityEvent IncreasingBeginEvent;
        public UnityEvent IncreasingEndEvent;

        public UnityEvent DecreasingBeginEvent;
        public UnityEvent DecreasingEndEvent;

        public override void Begin(bool increasing) {
            if (increasing) {
                if (!Increasing) {
                    IncreasingBeginEvent.Invoke();
                }
            } else {
                if (Increasing) {
                    DecreasingBeginEvent.Invoke();
                }
            }
            base.Begin(increasing);
        }

        public override void End() {
            if (Increasing) {
                IncreasingEndEvent.Invoke();
            } else {
                DecreasingEndEvent.Invoke();
            }
            base.End();
        }
    }
}