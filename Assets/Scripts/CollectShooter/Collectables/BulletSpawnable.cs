using UnityEditor;
using UnityEngine;

namespace CollectShooter.Collectables
{
    public class BulletSpawnable : MonoBehaviour
    {
        public BulletEntity prefab;
        public BulletEntity instance;
        
        public void Spawn()
        {
#if UNITY_EDITOR
            Clear();
            instance = PrefabUtility.InstantiatePrefab(prefab, transform) as BulletEntity;
            instance.transform.localPosition = Vector3.zero;
            instance.transform.localRotation = Quaternion.identity;
#endif
        }

        public void Clear()
        {
            if(instance != null)
                DestroyImmediate(instance.gameObject);
        }
        
        
    }
}