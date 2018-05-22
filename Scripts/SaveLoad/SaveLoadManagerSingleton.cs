
namespace RichUnity.SaveLoad
{
    public class SaveLoadManagerSingleton : SaveLoadManager
    {
        // a beautiful boilerplate
        
        public static SaveLoadManagerSingleton Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(transform.gameObject);
                //base.Awake();
            }
            else
            {
                //Singleton already exists
                Destroy(gameObject);
            }
        }
    }
}