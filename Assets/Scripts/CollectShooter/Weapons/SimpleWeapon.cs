using System.Collections;
using CollectShooter.Collectables;
using DG.Tweening;
using UnityEngine;

namespace CollectShooter.Weapons
{
    public class SimpleWeapon : MonoBehaviour, IWeapon
    {
        public WeaponEntity weaponEntity;
        private bool _isFiring = false;

        private void Awake()
        {
            weaponEntity.magazine.Init(weaponEntity);
        }

        public bool CanTake()
        {
            return !weaponEntity.magazine.IsFull();
        }

        public void TakeItem(IBackpackItem item, IWeaponUser user)
        {
            weaponEntity.magazine.PushItem(item, user.GetTeam());
        }

        [ContextMenu("Start Firing")]
        public void StartFiring()
        {
            weaponEntity.triggerCollider.enabled = false;
            weaponEntity.wall.entity.health = weaponEntity.magazine.Count;
            weaponEntity.wall.PrepareForShooting();
            weaponEntity.rotator.RotateToInPlane(weaponEntity.wall.LookAtPosition().position, () =>
            {
                Debug.Log("rotated");
                StartCoroutine(Firing());
            });
   
        }

        public void Claim(IWeaponUser user)
        {
            
        }

        public Vector3 LookAtPosition()
        {
            return transform.position;
        }
        
        private void OnEnable()
        {
            weaponEntity.magazine.OnFull += OnFull;
        }

        private void OnDisable()
        {
            weaponEntity.magazine.OnFull -= OnFull;
        }

        private void OnFull()
        {
            _isFiring = true;
            OnDisable();
            StartFiring();
        }

        private IEnumerator Firing()
        {
            var delay = weaponEntity.settings.firingDelay;
            var count = weaponEntity.magazine.Count;
            var startCount = count;
            while (count > 0)
            {
                // Debug.Log($"fire: count: {count}");
                count--;
                weaponEntity.wall.Damage(1);
                weaponEntity.particles.Play();
                weaponEntity.display.UpdateCountDown(count, startCount);
                yield return new WaitForSeconds(delay);
            }
            EndFiring();
        }

        private void EndFiring()
        {
            transform.DOScale(Vector3.zero, weaponEntity.settings.scaleDownTime).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}