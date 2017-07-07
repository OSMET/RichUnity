using RichUnity.Save.DataLoaders;
using UnityEngine;

namespace RichUnity.Save.DataLoaderBundles {
    public abstract class DataLoaderBundle : MonoBehaviour {
        public abstract IDataLoader[] DataLoaders { get; }
    }
}
