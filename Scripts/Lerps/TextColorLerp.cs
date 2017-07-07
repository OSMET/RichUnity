using UnityEngine;
using UnityEngine.UI;

namespace RichUnity.Lerps {
    [RequireComponent(typeof(Text))]
    public class TextColorLerp : Lerp<Color> {
        public override void ChangeValue(float percentage) {
            GetComponent<Text>().color = Color.Lerp(BeginValue, EndValue, percentage);
        }
    }
}
