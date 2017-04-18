using Assets.Plugins.RichUnity.Timers;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Lerps {
    public class ScaleLerp : MonoBehaviour {
        public EventTimer ScaleTimer;
        public Vector3 MinScale;


        private bool grow;
        private Vector3 maxScale;

        public void Start() {
            maxScale = transform.localScale;
            ScaleTimer.Ended += ScaleTimer_Ended;
            ScaleTimer.Looped = true;
            ScaleTimer.Start();
        }

        private void ScaleTimer_Ended(object sender, System.EventArgs e) {
            grow = !grow;
        }

        public void Update() {
            ScaleTimer.Update(Time.deltaTime);
            float timePercent = grow ? ScaleTimer.CompletedPercent : ScaleTimer.RemainingPercent;
            transform.localScale = Vector3.Lerp(MinScale, maxScale, timePercent);
        }

    }
}
