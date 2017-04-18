using Assets.Plugins.RichUnity.Timers;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Lerps {
    class PositionLerp : MonoBehaviour {
        public EventTimer PositionTimer;
        public Vector3 MinPosition;

        private bool grow;
        private Vector3 maxPosition;

        public void Start() {
            maxPosition = transform.localPosition;
            PositionTimer.Ended += PositionTimer_Ended;
            PositionTimer.Looped = true;
            PositionTimer.Start();
        }

        private void PositionTimer_Ended(object sender, System.EventArgs e) {
            grow = !grow;
        }

        public void Update() {
            PositionTimer.Update(Time.deltaTime);
            float timePercent = grow ? PositionTimer.CompletedPercent : PositionTimer.RemainingPercent;
            transform.localPosition = Vector3.Lerp(MinPosition, maxPosition, timePercent);
        }

    }
}
