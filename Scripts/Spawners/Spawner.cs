using UnityEngine;

namespace RichUnity.Spawners {
    public abstract class Spawner : MonoBehaviour {
        public bool SpawnAsChild;

        public abstract GameObject Spawn();
        
        protected virtual GameObject InstantiateObject(GameObject prefab) {
            return SpawnAsChild ? Instantiate(prefab, transform) : Instantiate(prefab);
        }
    }
}