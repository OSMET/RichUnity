using UnityEngine;

namespace RichUnity.Lerps {
    public class RotationLerp : Lerp<Vector3> {
        public override void ChangeValue(float percentage) {
            transform.eulerAngles = Vector3.Lerp(BeginValue, EndValue, percentage);
        }
    }
}
