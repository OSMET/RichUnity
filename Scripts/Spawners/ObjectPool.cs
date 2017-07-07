using System.Collections.Generic;
using UnityEngine;

namespace RichUnity.Spawners {
    public class ObjectPool : MonoBehaviour, ISpawner {
        public abstract class PoolableObject : MonoBehaviour {
            public ObjectPool ObjectPool { get; set; }

            public virtual void OnEnable() {
            }

            public virtual void OnDisable() {
                if (ObjectPool != null) {
                    ObjectPool.PoolObject(this);
                } else {
                    Destroy(gameObject);
                }
            }
        }


        public PoolableObject ObjectPrefab;
        public int InitialSize;
        public bool WillGrow = true;
        public bool SpawnAsChild = true;

        private Stack<GameObject> objects;

        public virtual void Awake() {
            objects = new Stack<GameObject>(InitialSize);
        }

        public virtual void Start() {
            for (var i = 0; i < InitialSize; ++i) {
                var obj = InstantiateObject();
                obj.SetActive(false);
                //objects.Push(obj);
            }
        }

        private void PoolObject(PoolableObject obj) {
            objects.Push(obj.gameObject);
        }

        public virtual GameObject Spawn() {
            GameObject obj;
            if (objects.Count == 0) {
                if (WillGrow) {
                    obj = InstantiateObject();
                } else {
                    return null;
                }
            } else {
                obj = objects.Pop();
                obj.SetActive(true);
            }

            return obj;
        }

        public T Spawn<T>() where T : PoolableObject {
            return (T) Spawn().GetComponent<PoolableObject>();
        }

        private GameObject InstantiateObject() {
            GameObject obj = SpawnAsChild
                ? Instantiate<GameObject>(ObjectPrefab.gameObject, transform)
                : Instantiate<GameObject>(ObjectPrefab.gameObject);
            obj.GetComponent<PoolableObject>().ObjectPool = this;
            return obj;
        }

        public virtual void OnDestroy() {
            if (objects != null) {
                GameObject[] objectsArray = objects.ToArray();
                foreach (GameObject obj in objectsArray) {
                    if (obj.gameObject != null) {
                        if (!obj.activeInHierarchy) {
                            Destroy(obj);
                        }
                    }
                }
            }
        }
    }
}