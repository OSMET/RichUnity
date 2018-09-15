using UnityEngine;

namespace RichUnity.Spawners.AwakeSpawners
{
    public class PrefabSpawner : Spawner
    {
        public GameObject ObjectPrefab;

        public override GameObject Spawn()
        {
            return InstantiateObject(ObjectPrefab);
        }
    }
}