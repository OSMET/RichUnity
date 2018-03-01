using UnityEngine;

namespace RichUnity.Spawners {
    [System.Serializable]
    public class RandomResourcePrefabAwakeSpawner : AwakeSpawner {

        public string ResourceFolderPath;

        private GameObject[] prefabs;

        protected override void Awake() {
            prefabs = Resources.LoadAll<GameObject>(ResourceFolderPath);
            base.Awake();
        }

        public override GameObject Spawn() {
            var randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            return InstantiateObject(randomPrefab);
        }
    }
}
