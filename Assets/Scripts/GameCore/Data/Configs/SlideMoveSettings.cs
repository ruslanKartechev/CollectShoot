using UnityEngine;

namespace GameCore.Data.Configs
{
    [CreateAssetMenu(fileName = nameof(SlideMoveSettings), menuName = "SO/" + nameof(SlideMoveSettings))]
    public class SlideMoveSettings : ScriptableObject
    {
        public float ScreenWidthFraction;
        public float SideMoveSpeed;
        public float FowardMoveSpeed;
        public float MaxOffset;
    }
}