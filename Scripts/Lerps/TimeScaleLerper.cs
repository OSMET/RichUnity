namespace RichUnity.Lerps {
    public class TimeScaleLerper : Lerper {
        public float TimeScale = 1f;

        protected override float DeltaTime {
            get {
                return base.DeltaTime * TimeScale;
            }
        }
    }
}
