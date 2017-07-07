using UnityEngine;

namespace RichUnity.Lerps {
    public class RectPositionLerp : Lerp<Vector3> {

        public bool LerpAnchoredPosition = false;

        public override void ChangeValue(float percentage) {
            var rectPosition = GetComponent<RectTransform>();

            var newPosition = Vector3.Lerp(BeginValue, EndValue, percentage);
            //newPosition.x += rectPosition.anchorMax.x;
            //newPosition.y += rectPosition.anchorMax.y;
            if (LerpAnchoredPosition) {
                rectPosition.anchoredPosition = newPosition;
            } else {
                rectPosition.position = newPosition;
            }
        }
    }
}
