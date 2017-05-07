using Assets.Plugins.RichUnity.Save.DataLoaders;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Save.DataLoaderBundles {
    public abstract class DataLoaderBundle : MonoBehaviour {
        public abstract IDataLoader[] DataLoaders { get; }
    }
}
