using UnityEngine;

namespace RichUnity.Audio.AudioPlugs
{
    [CreateAssetMenu(fileName = "SimpleSingleAudioPlug", menuName = "Rich Unity/Audio/Audio Plugs/Simple Single Audio Plug")]
    public class SimpleSingleAudioPlug : SimpleAudioPlug
    {
        [SerializeField]
        private AudioClip audioClip;

        protected override AudioClip AudioClip
        {
            get
            {
                return audioClip;
            }
        }
    }
}