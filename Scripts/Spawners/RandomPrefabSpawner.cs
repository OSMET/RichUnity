using UnityEngine;

namespace RichUnity.Spawners {
    [System.Serializable]
    public class RandomPrefabSpawner : ISpawner {

        public string ResourceFolderPath;

        private GameObject[] prefabs;

        public void LoadPrefabs() {
            prefabs = Resources.LoadAll<GameObject>(ResourceFolderPath);
        }

        public GameObject Spawn() {
            var randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            return Object.Instantiate(randomPrefab);
        }
    }
}
