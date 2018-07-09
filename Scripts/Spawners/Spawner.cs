using UnityEngine;

namespace RichUnity.Spawners
{
    public abstract class Spawner : MonoBehaviour
    {
        public bool SpawnAsChild;

        public abstract GameObject Spawn();

        protected virtual GameObject InstantiateObject(GameObject prefab)
        {
            return SpawnAsChild ? Instantiate(prefab, transform) : Instantiate(prefab);
        }

        public virtual T Spawn<T>() where T : MonoBehaviour
        {
            var spawnedObject = Spawn();
            return spawnedObject != null ? spawnedObject.GetComponent<T>() : null;
        }
    }
}