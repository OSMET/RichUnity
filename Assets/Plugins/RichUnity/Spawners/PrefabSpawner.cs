using UnityEngine;

namespace Assets.Plugins.RichUnity.Spawners {
    public class PrefabSpawner : MonoBehaviour, ISpawner {
        public GameObject ObjectPrefab;
        public bool SpawnAsChild;

        public virtual void Awake() {
            GameObject obj = Spawn();
            if (SpawnAsChild) {
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        public GameObject Spawn() {
            GameObject obj;
            if (SpawnAsChild) {
                obj = Instantiate(ObjectPrefab, transform);
            } else {
                obj = Instantiate(ObjectPrefab);
            }
            return obj;

        }
    }
}
