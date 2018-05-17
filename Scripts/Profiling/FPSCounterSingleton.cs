using UnityEngine;

namespace RichUnity.Profiling
{
    public class FPSCounterSingleton : FPSCounter
    {
        private static FPSCounterSingleton instance;
        
        private static object _lock = new object();

        public static FPSCounterSingleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<FPSCounterSingleton>();
                        if (instance == null)
                        {
                            var singleton = new GameObject
                            {
                                name = typeof(FPSCounterSingleton).ToString()
                            };
                            instance = singleton.AddComponent<FPSCounterSingleton>();

                            Debug.Log("[Singleton] An instance of " + typeof(FPSCounterSingleton) +
                                      " is needed in the scene, so '" + singleton +
                                      "' was created.");
                        }
                    }

                    return instance;
                }
            }
        }

        protected override void Awake ()
        {
            if (instance == null)
            {
                instance = this;
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