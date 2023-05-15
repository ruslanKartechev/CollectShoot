using UnityEngine;

namespace GameCore.Data
{
    [CreateAssetMenu(fileName = nameof(BootSettings), menuName = "SO/" + nameof(BootSettings))]
    public class BootSettings : ScriptableObject
    {
        public bool UseCheats;
        public bool SaveOnExit;
        public bool ShowWeaponOffers = true;
    }
}