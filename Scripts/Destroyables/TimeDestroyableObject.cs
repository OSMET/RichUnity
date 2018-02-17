using UnityEngine;

namespace RichUnity.Destroyables {
    public abstract class TimeDestroyableObject : MonoBehaviour {
        public float DestroyTime;

        private void Start() {
            Destroy(gameObject, DestroyTime);
        }
    }
}