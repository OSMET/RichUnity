using UnityEngine;

namespace RichUnity.Destroyables {
    [RequireComponent(typeof(ParticleSystem))]
    public class AutoDestroyablePS : MonoBehaviour {
        public ParticleSystem ParticleSystem { get; set; }

        public void Start() {
            ParticleSystem = GetComponent<ParticleSystem>();
        }

        public void Update() {
            if (!ParticleSystem.IsAlive()) {
                Destroy(gameObject);
            }
        }
    }
}