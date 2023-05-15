using UnityEngine;

namespace CollectShooter.Collectables
{
    [CreateAssetMenu(menuName = "SO/" + nameof(BackpackSettings), fileName = nameof(BackpackSettings), order = 0)]
    public class BackpackSettings : ScriptableObject
    {
        public int MaxCapacity;
        public float ItemsOffset;
        public float ItemPullDelay = 0.25f;
    }
}