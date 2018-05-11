using UnityEngine;

namespace RichUnity.Spawners
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