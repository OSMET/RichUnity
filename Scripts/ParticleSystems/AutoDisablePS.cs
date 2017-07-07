using UnityEngine;

namespace RichUnity.ParticleSystems {
    [RequireComponent(typeof(ParticleSystem))]
    public class AutoDisablePS : MonoBehaviour {

        public ParticleSystem ParticleSystem { get; set; }

        public virtual void Awake() {
            ParticleSystem = GetComponent<ParticleSystem>();
        }

        public void Update() {
            if (!ParticleSystem.IsAlive()) {
                gameObject.SetActive(false);
            }
        }
    }
}
