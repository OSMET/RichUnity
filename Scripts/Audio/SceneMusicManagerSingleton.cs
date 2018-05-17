namespace RichUnity.Audio
{
    public class SceneMusicManagerSingleton : SceneMusicManager
    {
        // a beautiful boilerplate
        
        public static SceneMusicManagerSingleton Instance { get; private set; }

        protected override void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(transform.gameObject);
                base.Awake();
            }
            else
            {
                //Singleton already exists
                Destroy(gameObject);
            }
        }
    }
}