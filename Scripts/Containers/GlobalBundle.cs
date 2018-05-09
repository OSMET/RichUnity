using RichUnity.Singletons;

namespace RichUnity.Containers {
    public class GlobalBundle : PersistentSingleton<GlobalBundle> {
        public static GlobalBundle Instance { get; private set; }

        public Bundle Bundle { get; private set; }
    }
}
