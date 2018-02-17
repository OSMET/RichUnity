using UnityEngine;

namespace RichUnity.ParticleSystems {
    [RequireComponent(typeof(ParticleSystem))]
    public class AutoDisablePS : MonoBehaviour {

        public ParticleSystem ParticleSystem { get; private set; }

        protected virtual void Awake() {
            ParticleSystem = GetComponent<ParticleSystem>();
        }

        protected virtual void Update() {
            if (!ParticleSystem.IsAlive()) {
                gameObject.SetActive(false);
            }
        }
    }
}
