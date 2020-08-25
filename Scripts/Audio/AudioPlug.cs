using RichUnity.Scripts.Ranges;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Audio;

namespace RichUnity.Audio
{
    [CreateAssetMenu(fileName = "AudioPlug", menuName = "RichUnity/Audio/Audio Plug")]
    public sealed class AudioPlug : ScriptableObject
    {
        public AudioMixerGroup OutputAudioMixerGroup;
        // public bool Muted;

        [SerializeField]
        [MinMaxFloatRange(0.0f, 1.0f)]
        private FloatRange volumeRange = new FloatRange
        {
            MinValue = 1.0f,
            MaxValue = 1.0f
        };

        [SerializeField]
        [MinMaxFloatRange(0.0f, 3.0f)]
        private FloatRange pitchRange = new FloatRange
        {
            MinValue = 1.0f,
            MaxValue = 1.0f
        };

        [SerializeField]
        private AudioClip[] audioClips;
        

        public FloatRange VolumeRange => volumeRange;

        public FloatRange PitchRange => pitchRange;
        
        public AudioClip[] AudioClips => audioClips;


        public void PlayClip(AudioSource audioSource, int index)
        {
            if (audioClips.Length > 0)
            {
                audioSource.clip = audioClips[index];
                audioSource.outputAudioMixerGroup = OutputAudioMixerGroup;
                // audioSource.mute = Muted;
                audioSource.volume = volumeRange.RandomValue;
                audioSource.pitch = pitchRange.RandomValue;

                audioSource.Play();
            }
        }
        
        public void PlayRandomClip(AudioSource audioSource)
        {
            if (audioClips.Length > 0)
            {
                PlayClip(audioSource, Random.Range(0, audioClips.Length));
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AudioPlug), true)]
    public class AudioPlugEditor : Editor
    {
        [SerializeField]
        private AudioSource previewAudioSource;

        public void OnEnable()
        {
            previewAudioSource = EditorUtility
                .CreateGameObjectWithHideFlags("PreviewAudioSource", HideFlags.HideAndDontSave, typeof(AudioSource))
                .GetComponent<AudioSource>();
        }

        public void OnDisable()
        {
            DestroyImmediate(previewAudioSource.gameObject);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
            if (GUILayout.Button("Preview"))
            {
                ((AudioPlug) target).PlayRandomClip(previewAudioSource);
            }

            EditorGUI.EndDisabledGroup();
        }
    }
#endif
}