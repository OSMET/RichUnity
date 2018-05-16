using UnityEngine;

namespace RichUnity.Audio.AudioPlugs
{
    [CreateAssetMenu(fileName = "SimpleMultiAudioPlug", menuName = "RichUnity/Audio/Audio Plugs/Simple Multi Audio Plug")]
    public class SimpleMultiAudioPlug: SimpleAudioPlug
    { 
        [SerializeField]
        private AudioClip[] audioClips;

        protected override AudioClip AudioClip
        {
            get
            {
                return audioClips.Length == 0 ? null : audioClips[Random.Range(0, audioClips.Length)];
            }
        }
    }
}