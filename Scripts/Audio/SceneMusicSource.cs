using UnityEngine;

namespace RichUnity.Audio
{
//    [RequireComponent(typeof(AudioSource))]
//    public class SceneMusicSource : RichAudioSource
//    {
//        public static SceneMusicSource Instance { get; private set; }
//
//        public SceneMusicSource() : base()
//        {
//            AudioClassName = "Music";
//        }
//
//        protected override void Awake()
//        {
//            base.Awake();
//            if (Instance == null)
//            {
//                Instance = this;
//                DontDestroyOnLoad(gameObject);
//            }
//            else if (Instance != this)
//            {
//                bool clipsAreDifferent = Instance.AudioSource.clip != AudioSource.clip;
//
//                Instance.AudioSource.clip = AudioSource.clip;
//                Instance.AudioSource.mute = AudioSource.mute;
//                Instance.AudioSource.bypassEffects = AudioSource.bypassEffects;
//                Instance.AudioSource.bypassListenerEffects = AudioSource.bypassListenerEffects;
//                Instance.AudioSource.bypassReverbZones = AudioSource.bypassReverbZones;
//                Instance.AudioSource.playOnAwake = AudioSource.playOnAwake;
//
//                Instance.AudioSource.priority = AudioSource.priority;
//                Instance.Volume = Volume;
//                Instance.AudioSource.pitch = AudioSource.pitch;
//                Instance.AudioSource.panStereo = AudioSource.panStereo;
//                Instance.AudioSource.spatialBlend = AudioSource.spatialBlend;
//                Instance.AudioSource.reverbZoneMix = AudioSource.reverbZoneMix;
//
//                Instance.AudioSource.dopplerLevel = AudioSource.dopplerLevel;
//                Instance.AudioSource.spread = AudioSource.spread;
//                Instance.AudioSource.rolloffMode = AudioSource.rolloffMode;
//                Instance.AudioSource.minDistance = AudioSource.minDistance;
//                Instance.AudioSource.maxDistance = AudioSource.maxDistance;
//
//                if (AudioSource.playOnAwake)
//                {
//                    if (clipsAreDifferent)
//                    {
//                        Instance.Play();
//                    }
//                }
//                else
//                {
//                    Instance.Stop();
//                    Instance.AudioSource.mute = true;
//                }
//
//                Destroy(gameObject);
//            }
//        }
//    }
}