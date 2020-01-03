using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RichUnity.Audio
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(AudioSource))]
    public class AudioClipButtonHighlight : MonoBehaviour, IPointerEnterHandler
    {
        private AudioSource audioSource;
        
        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }
        
        public void OnPointerEnter(PointerEventData pointerEventData) {
           audioSource.Play();
        }
    }
}