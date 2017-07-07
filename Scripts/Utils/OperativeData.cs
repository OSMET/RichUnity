namespace RichUnity.Utils {
    public class OperativeData : ObjectSceneLimiter {
        public static OperativeData Instance;

        public Bundle Data { get; private set; }

        public override void Awake() {
            if (Instance == null) {
                Instance = this;
                Data = new Bundle();
                base.Awake();
            } else if (Instance != this) {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}
