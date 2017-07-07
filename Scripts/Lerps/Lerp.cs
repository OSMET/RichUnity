using UnityEngine;

namespace RichUnity.Lerps {
    public abstract class Lerp : MonoBehaviour {
        public abstract void ChangeValue(float percentage);
    }

    public abstract class Lerp<T> : Lerp {
        public T BeginValue;
        public T EndValue;
    }
}
