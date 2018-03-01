using UnityEngine;

namespace RichUnity.Spawners {
    [System.Serializable]
    public class RandomResourcePrefabSpawner : Spawner {

        public string ResourceFolderPath;

        private GameObject[] prefabs;

        protected void Awake() {
            prefabs = Resources.LoadAll<GameObject>(ResourceFolderPath);
        }

        public override GameObject Spawn() {
            var randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            return InstantiateObject(randomPrefab);
        }
    }
}
