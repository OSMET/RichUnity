namespace RichUnity.Lerps.Lerpers {
    public class TimeScaleUnityEventLerper : UnityEventLerper {
        public float TimeScale = 1f;

        protected override float DeltaTime {
            get {
                return base.DeltaTime * TimeScale;
            }
        }
    }
}
