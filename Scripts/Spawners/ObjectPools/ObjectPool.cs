using System.Collections.Generic;
using UnityEngine;

namespace RichUnity.Spawners.ObjectPools
{
    public class ObjectPool : MonoBehaviour
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
        public bool SpawnAsChild;

        private Stack<PoolableObject> objects;

        public int AvailableCount
        {
            get
            {
                return objects.Count;
            }
        }

        public void Initialize() // can be called on awake if you want to, otherwise will be called on start automatically
        {
            objects = new Stack<PoolableObject>(InitialSize);
            for (int index = 0; index < InitialSize; index++)
            {
                var obj = InstantiateObject(ObjectPrefab);
                obj.gameObject.SetActive(false);
                //objects.Push(obj); //because of OnDisable invocation
            }
        }

        protected virtual void Start()
        {
            if (objects != null)
            {
                Initialize();
            }
        }

        private void PoolObject(PoolableObject obj)
        {
            objects.Push(obj);
        }

        public virtual PoolableObject Spawn()
        {
            PoolableObject obj;
            if (objects.Count == 0)
            {
                if (AbleToExpand)
                {
                    obj = InstantiateObject(ObjectPrefab);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                obj = objects.Pop();
                obj.gameObject.SetActive(true);
            }

            return obj;
        }

        public T Spawn<T>() where T : PoolableObject
        {
            return (T) Spawn();
        }

        private PoolableObject InstantiateObject(PoolableObject prefab)
        {
            var obj = SpawnAsChild ? Instantiate(prefab, transform) : Instantiate(prefab);
            obj.ObjectPool = this;
            return obj;
        }

        protected virtual void OnDestroy()
        {
            if (objects != null)
            {
                while (objects.Count > 0)
                {
                    var obj = objects.Pop();
                    if (obj != null && !obj.gameObject.activeInHierarchy)
                    {
                        Destroy(obj);
                    }
                }
            }
        }
    }
}