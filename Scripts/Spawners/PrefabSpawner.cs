using UnityEngine;

namespace RichUnity.Spawners {
    public class PrefabSpawner : MonoBehaviour, ISpawner {
        public GameObject ObjectPrefab;
        public bool SpawnAsChild;

        public virtual void Awake() {
            GameObject obj = Spawn();
            if (SpawnAsChild) {
                obj.transform.localPosition = ObjectPrefab.transform.localPosition;
                obj.transform.localRotation = ObjectPrefab.transform.localRotation;
                obj.transform.localScale = ObjectPrefab.transform.localScale;
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
