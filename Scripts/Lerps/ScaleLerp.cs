using UnityEngine;

namespace RichUnity.Lerps {
    public class ScaleLerp : Lerp<Vector3> {
        public override void ChangeValue(float percentage) {
            transform.localScale = Vector3.Lerp(BeginValue, EndValue, percentage);
        }
    }
}
