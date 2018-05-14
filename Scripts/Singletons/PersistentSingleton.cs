using UnityEngine;

namespace RichUnity.Singletons
{
    public class PersistentSingleton<T> : MonoBehaviour where T : PersistentSingleton<T>
    {
        private static T instance;
        
        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        protected virtual void Awake()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(transform.gameObject);
                OnSingletonAwake();
            }
            else
            {
                //Singleton already exists
                Destroy(gameObject);
            }
        }

        protected virtual void OnSingletonAwake()
        {
        }
    }
}