using UnityEngine;

namespace RichUnity.Lerps {
    public class PositionLerp : Lerp<Vector3> {

        public bool LerpLocalPosition = false;

        public override void ChangeValue(float percentage) {
            var newPosition = Vector3.Lerp(BeginValue, EndValue, percentage);
            if (LerpLocalPosition) {
                transform.localPosition = newPosition;
            } else {
                transform.position = newPosition;
            }
        }
    }
}
