using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.UI {
    [RequireComponent(typeof(Button))]
    public class FollowLinkButton : MonoBehaviour {

        public string Link;

        private void Awake() {
            GetComponent<Button>().onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick() {
            Application.OpenURL(Link);
        }
    }
}
