using RichUnity.Audio.AudioPlugs;
using UnityEngine;

namespace RichUnity.Audio
{
    public class AudioPlugSource : MonoBehaviour
    {
        public AudioSource AudioSource { get; private set; }

        public AudioPlug AudioPlug;

        public bool PlayOnAwake;
        public bool Loop;

        private bool playBegan;

        protected virtual void Awake()
        {
            AudioSource = gameObject.AddComponent<AudioSource>();
            if (PlayOnAwake)
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