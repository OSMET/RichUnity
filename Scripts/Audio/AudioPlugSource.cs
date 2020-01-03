using UnityEngine;

namespace RichUnity.Audio
{
    public class AudioPlugSource : MonoBehaviour
    {
        private AudioSource audioSource;

        public AudioPlug AudioPlug;

        [SerializeField]
        public bool playOnAwake;

        public bool PlayOnAwake
        {
            get
            {
                return playOnAwake;
            }
            set
            {
                playOnAwake = value;
                audioSource.playOnAwake = value;
            }
        }
        public bool Loop;

        private bool playBegan;

        protected virtual void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false;
            }
            if (playOnAwake)
            {
                Play();
            }
        }

        public void Play()
        {
            AudioPlug.Play(audioSource);
            playBegan = Loop;
        }

        public void Stop()
        {
            audioSource.Stop();
            audioSource.clip = null;
            playBegan = false;
        }

        protected virtual void Update()
        {
            if (playBegan)
            {
                if (Loop)
                {
                    if (!audioSource.isPlaying)
                    {
                        playBegan = false;
                        Play();
                    }
                }
                else
                {
                    playBegan = false;
                }
            }

        }
    }
}