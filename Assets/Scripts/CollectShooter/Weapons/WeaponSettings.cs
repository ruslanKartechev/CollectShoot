using UnityEngine;

namespace CollectShooter.Weapons
{
    [CreateAssetMenu(menuName = "SO/" + nameof(WeaponSettings), fileName = nameof(WeaponSettings), order = 0)]
    public class WeaponSettings : ScriptableObject
    {
        public float itemTakeTime;
        public float firingDelay;
        public float rotateToFaceTime;
        public float scaleDownTime;
        public Vector3 sideAngles;
    }
}