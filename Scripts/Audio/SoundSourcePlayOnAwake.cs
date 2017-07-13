using RichUnity.Audio;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Scripts.Audio {
    [RequireComponent(typeof(SoundSource))]
    public class SoundSourcePlayOnAwake : MonoBehaviour {

        public float Pitch = 1f;
        public float Volume = 1f;
        public bool Loop = false;

        public void Awake() {
            GetComponent<SoundSource>().PlaySound(Pitch, Volume, Loop);
            Destroy(this);
        }
    }
}
