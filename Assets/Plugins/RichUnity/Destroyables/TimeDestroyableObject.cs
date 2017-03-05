using UnityEngine;

namespace Assets.Plugins.RichUnity.Destroyables {
    public abstract class TimeDestroyableObject : MonoBehaviour {
        public float DestroyTime;

        public void Start() {
            Destroy(gameObject, DestroyTime);
        }
    }
}