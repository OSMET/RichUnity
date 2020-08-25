using System;
using System.Collections.Generic;
using RichUnity.Attributes;
using UnityEngine;

namespace RichUnity.Spawners.ObjectPools
{
    public class ObjectPool : MonoBehaviour
    { 
        public class PoolableObject : MonoBehaviour
        {
            [NonSerialized]
            public bool CanBePooled;
            
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
                        CanBePooled = true;
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
        public Transform ParentTransform;

        private Stack<PoolableObject> objects;

        public int AvailableCount => objects.Count;

        public void Initialize() // can be called on awake if you want to, otherwise will be called on start automatically
        {
            objects = new Stack<PoolableObject>(InitialSize);
            for (int index = 0; index < InitialSize; index++)
            {
                var obj = ParentTransform ? Instantiate(ObjectPrefab, ParentTransform) : Instantiate(ObjectPrefab);
                obj.ObjectPool = this;
                
                obj.gameObject.SetActive(false);

                obj.CanBePooled = true;
                
                PoolObject(obj);
            }
        }

        protected virtual void Start()
        {
            if (objects == null)
            {
                Initialize();
            }
        }

        private void PoolObject(PoolableObject obj)
        {
            if (obj.CanBePooled)
            {
                obj.CanBePooled = false;
                objects.Push(obj);
            }
        }

        public virtual PoolableObject Spawn()
        {
            PoolableObject obj;
            if (objects.Count == 0)
            {
                if (AbleToExpand)
                {
                    obj = ParentTransform ? Instantiate(ObjectPrefab, ParentTransform) : Instantiate(ObjectPrefab);
                    obj.ObjectPool = this;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                obj = objects.Pop();
            }
            
            obj.gameObject.SetActive(true);
            obj.CanBePooled = true;

            return obj;
        }

        public T Spawn<T>() where T : PoolableObject
        {
            return (T) Spawn();
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