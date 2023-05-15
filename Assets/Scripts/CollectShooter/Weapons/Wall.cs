using UnityEngine;

namespace CollectShooter.Weapons
{
    public class Wall : MonoBehaviour
    {
        public WallEntity entity;
        public Transform LookAtPosition() => transform;
        private bool _isBroken;
        private float _startHealth;

        public void Awake()
        {
            _startHealth = entity.health;
        }

        public void PrepareForShooting()
        {
            entity.display.SetValue(entity.health);
            entity.display.Show(false);    
        }
        
        public void Damage(float damage)
        {
            entity.health--;
            entity.display.UpdateValue(entity.health / _startHealth);
            if (entity.health <= 0)
            {
                entity.display.Hide(false);
                entity.body.BreakFromCenterDefault();
            }
        }

    }
}