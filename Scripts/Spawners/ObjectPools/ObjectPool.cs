using System.Collections.Generic;
using UnityEngine;

namespace RichUnity.Spawners.ObjectPools
{
    public class ObjectPool : Spawner
    { 
        public class PoolableObject : MonoBehaviour
        {
            private ObjectPool objectPool;

            public ObjectPool ObjectPool
            {
                get
                {
                    return objectPool;
                }
                set
                {
                    var oldObjectPool = objectPool;
                    
                    objectPool = value;
                    
                    if (objectPool == null && oldObjectPool != null) //an object will be detached if you null the property outside
                    {
                        transform.parent = oldObjectPool.transform.parent;
                    }
                }
            }

            protected virtual void OnDisable()
            {
                if (ObjectPool != null)
                {
                    ObjectPool.PoolObject(this);
                }
            }
        }

        public PoolableObject ObjectPrefab;
        public int InitialSize;
        public bool AbleToExpand = true;

        private Stack<GameObject> objects;

        public int AvailableObjectsCount => objects.Count;

        protected virtual void Awake()
        {
            objects = new Stack<GameObject>(InitialSize);
        }

        protected virtual void Start()
        {
            for (var i = 0; i < InitialSize; ++i)
            {
                var obj = InstantiateObject(ObjectPrefab.gameObject);
                obj.SetActive(false);
                //objects.Push(obj); //because OnDisable invocation
            }
        }

        private void PoolObject(PoolableObject obj)
        {
            objects.Push(obj.gameObject);
        }

        public override GameObject Spawn()
        {
            GameObject obj;
            if (objects.Count == 0)
            {
                if (AbleToExpand)
                {
                    obj = InstantiateObject(ObjectPrefab.gameObject);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                obj = objects.Pop();
                obj.SetActive(true);
            }

            return obj;
        }

        public new T Spawn<T>() where T : PoolableObject
        {
            return base.Spawn<T>();
        }

        protected override GameObject InstantiateObject(GameObject prefab)
        {
            var obj = base.InstantiateObject(prefab);
            obj.GetComponent<PoolableObject>().ObjectPool = this;
            return obj;
        }

        protected virtual void OnDestroy()
        {
            if (objects != null)
            {
                while (objects.Count > 0)
                {
                    var obj = objects.Pop();
                    if (obj.gameObject != null && !obj.activeInHierarchy)
                    {
                        Destroy(obj);
                    }
                }
            }
        }
    }
}