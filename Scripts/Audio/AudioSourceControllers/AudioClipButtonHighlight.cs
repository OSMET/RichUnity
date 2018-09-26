using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RichUnity.Audio.AudioSourceControllers
{
    [RequireComponent(typeof(Button))]
    public class AudioClipButtonHighlight : AudioSourceController, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData pointerEventData) {
           AudioSource.Play();
        }
    }
}