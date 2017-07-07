using UnityEngine;

namespace RichUnity.ParticleSystems {
    public class BurstPS : AutoDisablePS {
        private ParticleSystem.Burst[] bursts;

        public override void Awake() {
            base.Awake();
            bursts = new ParticleSystem.Burst[ParticleSystem.emission.burstCount];
            ParticleSystem.emission.GetBursts(bursts);
        }

        public void Burst() {
           if (!gameObject.activeSelf) {
                gameObject.SetActive(true);
            }
            foreach (var burst in bursts) {
                ParticleSystem.Emit(Random.Range(burst.minCount, burst.maxCount));
            }
        }
    }
}
