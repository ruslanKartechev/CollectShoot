using UnityEngine;

namespace CollectShooter.Collectables
{
    [CreateAssetMenu(menuName = "SO/" + nameof(CollectableSettings), fileName = nameof(CollectableSettings), order = 0)]
    public class CollectableSettings : ScriptableObject
    {
        public float flyTime;
        public float realSize;
        public Vector3 rotationInPack;
        public Vector3 scaleInPack = Vector3.one;
    }
}