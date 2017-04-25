using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Plugins.RichUnity.Faders {
    [RequireComponent(typeof(Image))]
    public class ImageFader : MonoBehaviour {

        public float FadeTime;

        private float currentTime;

        private bool started;
        private bool fadeIn;

        public UnityEvent FadeInEvent; //show, currentTime = 0
        public UnityEvent FadeOutEvent; //hide, currentTime = 1


        public void Update() {
            if (started) {
                if (fadeIn) { //show
                    currentTime -= Time.deltaTime;
                    if (currentTime <= 0f) {
                        started = false;
                        FadeInEvent.Invoke();
                    }
                } else { //hide
                    currentTime += Time.deltaTime;
                    if (currentTime >= FadeTime) {
                        started = false;
                        gameObject.SetActive(false);
                        FadeOutEvent.Invoke();

                    }
                }

                
                Image image = GetComponent<Image>();

                Color imageColor = image.color;
                imageColor.a = 1f - currentTime / FadeTime;
                image.color = imageColor;
            }
        }

        private void Fade(bool fadeIn) {
            gameObject.SetActive(true);
            started = true;
            this.fadeIn = fadeIn;
        }

        public void FadeIn() {
            Fade(true);
        }
        
        public void FadeOut() {
            Fade(false);
        }
    }
}
