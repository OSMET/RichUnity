using Assets.Plugins.RichUnity.Timers;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Plugins.RichUnity.Lerps {
    public class ScaleLerp : MonoBehaviour {
        public UnityEventTimer ScaleTimer;
        public Vector3 MinScale;


        private bool grow;
        private Vector3 maxScale;

        public void Start() {
            maxScale = transform.localScale;
            ScaleTimer.EndedEvent.AddListener(new UnityAction(ScaleTimer_Ended));
            ScaleTimer.Looped = true;
            ScaleTimer.Start();
        }

        private void ScaleTimer_Ended() {
            grow = !grow;
        }

        public void Update() {
            ScaleTimer.Update(Time.deltaTime);
            float timePercent = grow ? ScaleTimer.CompletedPercent : ScaleTimer.RemainingPercent;
            transform.localScale = Vector3.Lerp(MinScale, maxScale, timePercent);
        }

    }
}
