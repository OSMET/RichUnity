using UnityEngine;

namespace RichUnity.Spawners {
    public class PrefabAwakeSpawner : AwakeSpawner {
        public GameObject ObjectPrefab;
        
        public override GameObject Spawn() {
            return InstantiateObject(ObjectPrefab);
        }
    }
}