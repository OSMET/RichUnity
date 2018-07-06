using RichUnity.Singletons;

namespace RichUnity.SaveLoad
{
    public class SaveLoadManagerSingleton : PersistentSingleton<SaveLoadManagerSingleton>
    {
        public SaveLoadManager SaveLoadManager;
    }
}