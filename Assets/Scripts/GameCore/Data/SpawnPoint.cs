using UnityEngine;

namespace GameCore.Data
{
    [System.Serializable]
    public class SpawnPoint
    {
        public Transform parent;
        public Vector3 localPosition;
        public Vector3 localEulerRotation;

        public void Setup(Transform instance)
        {
            instance.transform.parent = parent;
            instance.localPosition = localPosition;
            instance.localEulerAngles = localEulerRotation;
        }
    }
}