using CollectShooter.Collectables;
using UnityEngine;

namespace CollectShooter.Weapons
{
    public interface IWeapon
    {
        bool CanTake();
        void TakeItem(IBackpackItem item, IWeaponUser user);
        void StartFiring();
        void Claim(IWeaponUser user);
        Vector3 LookAtPosition();
    }
}