using UnityEngine;

namespace RichUnity.Lerps {
    [RequireComponent(typeof(Sprite))]
    public class SpriteColorLerp : Lerp<Color> {
        public override void ChangeValue(float percentage) {
            GetComponent<SpriteRenderer>().color = Color.Lerp(BeginValue, EndValue, percentage);
        }
    }
}
