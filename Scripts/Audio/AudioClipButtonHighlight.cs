using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Button))]
    public class AudioClipButtonHighlight : MonoBehaviour, IPointerEnterHandler
    {
        public AudioSource AudioSource;
        
        public AudioClip AudioClip;
        
        
        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            if (AudioSource != null)
            {
                AudioSource.clip = AudioClip;
                
                AudioSource.Play();
            }
        }
    }
}