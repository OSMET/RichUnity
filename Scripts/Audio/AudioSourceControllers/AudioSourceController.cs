using UnityEngine;

namespace RichUnity.Audio.AudioSourceControllers
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AudioSourceController : MonoBehaviour
    {
        public AudioSource AudioSource { get; private set; }

        protected virtual void Awake()
        {
            AudioSource = GetComponent<AudioSource>();
        }
    }
}