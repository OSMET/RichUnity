using RichUnity.Singletons;

namespace RichUnity.Containers
{
    public class GlobalBundle : LazyPersistentSingleton<GlobalBundle>
    {
        public Bundle Bundle { get; private set; }
    }
}