using UnityEngine;

namespace RichUnity.DataSave {
    public abstract class DataLoadersBundle : MonoBehaviour {
        public abstract IDataLoader[] DataLoaders { get; }
    }
}
