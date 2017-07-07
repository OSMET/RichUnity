using UnityEngine;

namespace RichUnity.Destroyables {
    public abstract class TimeDestroyableObject : MonoBehaviour {
        public float DestroyTime;

        public void Start() {
            Destroy(gameObject, DestroyTime);
        }
    }
}