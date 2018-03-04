using RichUnity.DataSave.DataLoaders;
using UnityEngine;

namespace RichUnity.DataSave.DataLoaderBundles {
    public abstract class DataLoaderBundle : MonoBehaviour {
        public abstract IDataLoader[] DataLoaders { get; }
    }
}
