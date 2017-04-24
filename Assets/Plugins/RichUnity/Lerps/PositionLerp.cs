using Assets.Plugins.RichUnity.Timers;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Plugins.RichUnity.Lerps {
    public class PositionLerp : MonoBehaviour {
        public UnityEventTimer PositionTimer;
        public Vector3 MinPosition;

        private bool grow;
        private Vector3 maxPosition;

        public void Start() {
            maxPosition = transform.localPosition;
            PositionTimer.EndedEvent.AddListener(new UnityAction(PositionTimer_Ended));
            PositionTimer.Looped = true;
            PositionTimer.Start();
        }

        private void PositionTimer_Ended() {
            grow = !grow;
        }

        public void Update() {
            PositionTimer.Update(Time.deltaTime);
            float timePercent = grow ? PositionTimer.CompletedPercent : PositionTimer.RemainingPercent;
            transform.localPosition = Vector3.Lerp(MinPosition, maxPosition, timePercent);
        }

    }
}
