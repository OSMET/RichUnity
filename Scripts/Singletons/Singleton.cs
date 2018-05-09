using UnityEngine;

namespace RichUnity.Singletons
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
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
            instance = this as T;
        }
    }
}