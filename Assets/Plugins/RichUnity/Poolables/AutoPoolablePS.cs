using Assets.Plugins.RichUnity.Spawners;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Poolables {
    [RequireComponent(typeof(ParticleSystem))]
    public class AutoPoolablePS : ObjectPool.PoolableObject {

        public ParticleSystem ParticleSystem { get; set; }

        public void Start() {
            ParticleSystem = GetComponent<ParticleSystem>();
        }

        public void Update() {
            if (!ParticleSystem.IsAlive()) {
                gameObject.SetActive(false);
            }
        }
    }
}
