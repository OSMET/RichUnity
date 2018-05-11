using RichUnity.Singletons;

namespace RichUnity.Containers
{
    public class GlobalBundle : PersistentSingleton<GlobalBundle>
    {
        public Bundle Bundle { get; private set; }
    }
}