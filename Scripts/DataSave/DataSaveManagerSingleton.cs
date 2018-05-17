
namespace RichUnity.DataSave
{
    public class DataSaveManagerSingleton : DataSaveManager
    {
        // a beautiful boilerplate
        
        public static DataSaveManagerSingleton Instance { get; private set; }

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