namespace RichUnity.Lerps.Lerpers {
    public class TimeScaledEventLerper : EventLerper {
        public float TimeScale = 1f;

        protected override float DeltaTime {
            get {
                return base.DeltaTime * TimeScale;
            }
        }
    }
}
