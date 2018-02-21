using RichUnity.Spawners;
using UnityEngine;

namespace RichUnity.ParticleSystems {
    [RequireComponent(typeof(ParticleSystem))]
    public class AutoPoolablePS : ObjectPool.PoolableObject {

        public ParticleSystem ParticleSystem { get; private set; }

        private void Start() {
            ParticleSystem = GetComponent<ParticleSystem>();
        }

        private void Update() {
            if (!ParticleSystem.IsAlive()) {
                gameObject.SetActive(false);
            }
        }
    }
}
