using UnityEngine;

namespace RichUnity.Audio.AudioPlugs
{
    [CreateAssetMenu(fileName = "RangedMultiAudioPlug", menuName = "RichUnity/Audio/Audio Plugs/Ranged Multi Audio Plug")]
    public class RangedMultiAudioPlug: RangedAudioPlug
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