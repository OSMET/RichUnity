using UnityEngine;

namespace RichUnity.TimeUtils
{
    public class TimeDestroyableObject : MonoBehaviour
    {
        public float DestroyTime;

        protected virtual void OnEnable()
        {
            Destroy(gameObject, DestroyTime);
        }
    }
}