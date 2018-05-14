using RichUnity.Audio.AudioPlugs;
using UnityEngine;

namespace RichUnity.Audio
{
    public class AudioPlugSource : MonoBehaviour
    {
        private AudioSource AudioSource { get; set; }

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
                AudioSource.playOnAwake = value;
            }
        }
        public bool Loop;

        private bool playBegan;

        protected virtual void Awake()
        {
            AudioSource = gameObject.AddComponent<AudioSource>();
            if (playOnAwake)
            {
                Play();
            }
        }

        public void Play()
        {
            AudioPlug.Play(AudioSource);
            if (Loop)
            {
                playBegan = true;
            }
            else
            {
                playBegan = false;
            }
        }

        public void Stop()
        {
            AudioSource.Stop();
            AudioSource.clip = null;
            playBegan = false;
        }

        protected virtual void Update()
        {
            if (playBegan)
            {
                if (Loop)
                {
                    if (!AudioSource.isPlaying)
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