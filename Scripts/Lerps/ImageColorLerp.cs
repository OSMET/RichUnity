using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Lerps {
    [RequireComponent(typeof(Image))]
    public class ImageColorLerp : Lerp<Color> {
        public override void ChangeValue(float percentage) {
            GetComponent<Image>().color = Color.Lerp(BeginValue, EndValue, percentage);
        }
    }
}
