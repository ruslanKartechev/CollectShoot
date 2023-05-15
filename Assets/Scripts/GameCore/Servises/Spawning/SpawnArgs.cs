using UnityEngine;

namespace GameCore.Servises.Spawning
{
    public class SpawnArgs
    {
        public MonoBehaviour Prefab;
        public Transform Parent;
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale = Vector3.one;

        public SpawnArgs AddPrefab(MonoBehaviour prefab)
        {
            Prefab = prefab;
            return this;
        }

        public SpawnArgs AddParent(Transform parent)
        {
            Parent = parent;
            return this;
        }

        public SpawnArgs AddPosition(Vector3 position)
        {
            Position = position;
            return this;
        }

        public SpawnArgs AddRotation(Quaternion rotation)
        {
            Rotation = rotation;
            return this;
        }

        public SpawnArgs AddScale(Vector3 scale)
        {
            Scale = scale;
            return this;
        }

        public SpawnArgs AddRotation(Vector3 rotation)
        {
            Rotation = Quaternion.Euler(rotation);
            return this;
        }
        

    }
}