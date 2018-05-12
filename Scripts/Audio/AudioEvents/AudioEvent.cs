using UnityEngine;

namespace RichUnity.Audio.AudioEvents
{
    public abstract class AudioEvent : ScriptableObject
    {
        public abstract void Play(AudioSource audioSource);

        protected static void Play(AudioSource audioSource, AudioClip audioClip, float volume, float pitch)
        {
            audioSource.clip = audioClip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;

            audioSource.Play();
        }
    }
}