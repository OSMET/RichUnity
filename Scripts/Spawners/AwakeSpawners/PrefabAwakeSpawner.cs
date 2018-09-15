using UnityEngine;

namespace RichUnity.Spawners.AwakeSpawners
{
    public class PrefabAwakeSpawner : AwakeSpawner
    {
        public GameObject ObjectPrefab;

        public override GameObject Spawn()
        {
            return InstantiateObject(ObjectPrefab);
        }
    }
}