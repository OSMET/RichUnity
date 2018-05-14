﻿using UnityEngine;

namespace RichUnity.Audio.AudioPlugs
{
    [CreateAssetMenu(fileName = "RangedSingleAudioPlug", menuName = "Audio Plugs/Ranged Single Audio Plug")]
    public class RangedSingleAudioPlug : RangedAudioPlug
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