using UnityEngine;

namespace RichUnity.Destroyables {
    [RequireComponent(typeof(ParticleSystem))]
    public class AutoDestroyablePS : MonoBehaviour {
        public ParticleSystem ParticleSystem { get; set; }

        private void Start() {
            ParticleSystem = GetComponent<ParticleSystem>();
        }

        private void Update() {
            if (!ParticleSystem.IsAlive()) {
                Destroy(gameObject);
            }
        }
    }
}