using UnityEngine;

namespace RichUnity.Lerps {
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupAlphaLerp : Lerp<float> {
        public override void ChangeValue(float percentage) {
            GetComponent<CanvasGroup>().alpha = Mathf.Lerp(BeginValue, EndValue, percentage);
        }
    }
}
