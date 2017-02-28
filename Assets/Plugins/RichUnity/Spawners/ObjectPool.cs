using System.Collections.Generic;
using UnityEngine;

namespace Assets.Plugins.RichUnity.Spawners {
    [System.Serializable]
    public class ObjectPool : ISpawner {
        public class PoolableObject : MonoBehaviour {
            public ObjectPool ObjectPool { get; set;}

            public virtual void OnEnable() {
                
            }

            public virtual void OnDisable() {
                ObjectPool.PoolObject(this);
            }
        }


        public PoolableObject ObjectPrefab;
        public int InitialSize;
        public bool WillGrow = true;

        private Stack<GameObject> objects;

        public void Initialize() {
            objects = new Stack<GameObject>(InitialSize);

            for (var i = 0; i < InitialSize; ++i) {
                var obj = InstantiateObject();
                obj.SetActive(false);
                //objects.Push(obj);
            }
        }

        private void PoolObject(PoolableObject obj) {
            objects.Push(obj.gameObject);
        }

        public GameObject Spawn() {
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

        private GameObject InstantiateObject() {
            GameObject obj = Object.Instantiate<GameObject>(ObjectPrefab.gameObject);
            obj.GetComponent<PoolableObject>().ObjectPool = this;
            return obj;
        }
    }
}