using UnityEngine;

namespace GameCore.Data
{
    [CreateAssetMenu(fileName = nameof(MainConfig), menuName = "SO/" + nameof(MainConfig))]
    public class MainConfig : ScriptableObject
    {
        public bool UseHand = false;
        public float DataSavePeriod = 5f;
        public LayerMask mirrorsMask;

    }
} 
