using RichUnity.TransformUtils;
using UnityEngine;

namespace RichUnity.Spawners.AwakeSpawners
{
    public abstract class AwakeSpawner : Spawner
    {
        public enum TransformType
        {
            Prefab,
            Local,
            World,
        }

        public Vector3 SpawnPosition;
        public TransformType PositionTransformType = TransformType.Prefab;

        public Vector3 SpawnRotation;
        public TransformType RotationTransformType = TransformType.Prefab;

        public Vector3 SpawnScale = Vector3.one;
        public TransformType ScaleTransformType = TransformType.Prefab;

        protected virtual void Awake()
        {
            GameObject obj = Spawn();
            //position
            if (PositionTransformType == TransformType.Local)
            {
                obj.transform.localPosition = SpawnPosition;
            }
            else if (PositionTransformType == TransformType.World)
            {
                obj.transform.position = SpawnPosition;
            }

            //rotation
            if (RotationTransformType == TransformType.Local)
            {
                obj.transform.localRotation = Quaternion.Euler(SpawnRotation);
            }
            else if (RotationTransformType == TransformType.World)
            {
                obj.transform.rotation = Quaternion.Euler(SpawnRotation);
            }

            //scale
            if (ScaleTransformType == TransformType.Local)
            {
                obj.transform.localScale = SpawnScale;
            }
            else if (ScaleTransformType == TransformType.World)
            {
                obj.transform.SetGlobalScale(SpawnScale);
            }

            if (SpawnAsChild)
            {
                Destroy(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}