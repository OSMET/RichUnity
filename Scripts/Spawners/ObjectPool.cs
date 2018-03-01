using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RichUnity.Spawners {
    public class ObjectPool : Spawner {
        public class PoolableObject : MonoBehaviour {
            public ObjectPool ObjectPool { get; set; }

            protected virtual void OnEnable() {
            }

            protected virtual void OnDisable() {
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

        private Stack<GameObject> objects;

        protected virtual void Awake() {
            objects = new Stack<GameObject>(InitialSize);
        }

        protected virtual void Start() {
            for (var i = 0; i < InitialSize; ++i) {
                var obj = InstantiateObject(ObjectPrefab.gameObject);
                obj.SetActive(false);
                //objects.Push(obj); //because OnDisable invocation
            }
        }

        private void PoolObject(PoolableObject obj) {
            objects.Push(obj.gameObject);
        }

        public override GameObject Spawn() {
            GameObject obj;
            if (objects.Count == 0) {
                if (WillGrow) {
                    obj = InstantiateObject(ObjectPrefab.gameObject);
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

        protected override GameObject InstantiateObject(GameObject prefab) {
            var obj = base.InstantiateObject(prefab);
            obj.GetComponent<PoolableObject>().ObjectPool = this;
            return obj;
        }

        protected virtual void OnDestroy() {
            if (objects != null) {
                while (objects.Count > 0) {
                    var obj = objects.Pop();
                    if (obj.gameObject != null && !obj.activeInHierarchy) {
                        Destroy(obj);
                    }
                }
            }
        }
    }
}