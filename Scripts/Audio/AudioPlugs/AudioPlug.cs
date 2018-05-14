#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Audio;

namespace RichUnity.Audio.AudioPlugs
{
    public abstract class AudioPlug : ScriptableObject
    {
        public AudioMixerGroup OutputAudioMixerGroup;
        public bool Muted;
        
        public abstract float Volume { get; }
        
        public abstract float Pitch { get; }
        
        protected abstract AudioClip AudioClip { get; }

        public virtual void Play(AudioSource audioSource)
        {
            audioSource.clip = AudioClip;
            audioSource.outputAudioMixerGroup = OutputAudioMixerGroup;
            audioSource.mute = Muted;
            audioSource.volume = Volume;
            audioSource.pitch = Pitch;

            audioSource.Play();
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
                ((AudioPlug) target).Play(previewAudioSource);
            }

            EditorGUI.EndDisabledGroup();
        }
    }
#endif
}