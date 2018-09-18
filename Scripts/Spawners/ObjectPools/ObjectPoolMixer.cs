using System;
using RichUnity.Attributes;
using RichUnity.Math;
using UnityEngine;

namespace RichUnity.Spawners.ObjectPools
{
    public class ObjectPoolMixer : MonoBehaviour
    {
        public ObjectPool[] ObjectPools { get; private set; }

#if UNITY_EDITOR
        [ReadOnly]
        [SerializeField]
#endif
        private int lastSpawnedIndex;

        public int LastSpawnedIndex => lastSpawnedIndex;

        private void Awake()
        {
            ObjectPools = GetComponents<ObjectPool>();
        }
        
        public T Spawn<T>(int index) where T : ObjectPool.PoolableObject
        {
            lastSpawnedIndex = index;
            return SpawnLast<T>();
        }
        
        public T SpawnRandom<T>() where T : ObjectPool.PoolableObject
        {
            return Spawn<T>(UnityEngine.Random.Range(0, ObjectPools.Length));
        }
        
        public T SpawnWeightedRandom<T>(int[] weights) where T : ObjectPool.PoolableObject
        {
            if (weights.Length != ObjectPools.Length)
            {
                throw new ArgumentException();
            }
            return Spawn<T>(WeightedRandom.RandomIndex(weights));
        }
        
        public T SpawnWeightedRandomInitialSizes<T>() where T : ObjectPool.PoolableObject
        {
            int poolCount = ObjectPools.Length;
            var poolWeights = new int[poolCount];
            for (int i = 0; i < poolCount; ++i)
            {
                poolWeights[i] = ObjectPools[i].InitialSize;
            }
            return SpawnWeightedRandom<T>(poolWeights);
        }
        
        public T SpawnWeightedRandomAvailableCounts<T>() where T : ObjectPool.PoolableObject
        {
            int poolCount = ObjectPools.Length;
            var poolWeights = new int[poolCount];
            for (int i = 0; i < poolCount; ++i)
            {
                poolWeights[i] = ObjectPools[i].AvailableCount;
            }
            return SpawnWeightedRandom<T>(poolWeights);
        }

        public T SpawnLast<T>() where T : ObjectPool.PoolableObject
        {
            return ObjectPools[lastSpawnedIndex].Spawn<T>();
        }
        
        public T SpawnNext<T>() where T : ObjectPool.PoolableObject
        {
            lastSpawnedIndex++;
            if (lastSpawnedIndex == ObjectPools.Length)
            {
                lastSpawnedIndex = 0;
            }

            return SpawnLast<T>();
        }

        public T SpawnPrev<T>() where T : ObjectPool.PoolableObject
        {
            lastSpawnedIndex--;
            if (lastSpawnedIndex < 0)
            {
                lastSpawnedIndex = ObjectPools.Length - 1;
            }

            return SpawnLast<T>();
        }
        
        public T SpawnLastOrNext<T>() where T : ObjectPool.PoolableObject
        {
            return ObjectPools[lastSpawnedIndex].AvailableCount > 0 ? SpawnLast<T>() : SpawnNext<T>();
        }
        
        public T SpawnLastOrPrev<T>() where T : ObjectPool.PoolableObject
        {
            return ObjectPools[lastSpawnedIndex].AvailableCount > 0 ? SpawnLast<T>() : SpawnPrev<T>();
        }
    }
}