using UnityEngine;

namespace Assets.Plugins.RichUnity.Spawners {
    [System.Serializable]
    public class RandomPrefabSpawner : ISpawner {
        [SerializeField]
        private string resourceFolderPath;

        private GameObject[] prefabs;

        public RandomPrefabSpawner(string resourceFolderPath) {
            this.resourceFolderPath = resourceFolderPath;
        }

        public string ResourceFolderPath {
            get {
                return resourceFolderPath;
            }
        }

        public void LoadPrefabs() {
            prefabs = Resources.LoadAll<GameObject>(resourceFolderPath);
        }

        public GameObject Spawn() {
            var randomPrefab = prefabs[Random.Range(0, prefabs.Length)];
            return Object.Instantiate(randomPrefab);
        }
    }
}
