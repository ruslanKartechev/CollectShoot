using System;
using GameCore.Affectables.Damage;
using UnityEngine;

namespace GameCore.Stats.Health
{
    public class SimpleHealth : MonoBehaviour, IHealth, IDamageable
    {
        public event Action OnZeroHealth;
        
        protected float _health;
        protected float _maxHealth;
        protected bool _damageable = true;
        public float CurrentHealth => _health;
        public float MaxHealth => _maxHealth;
        
        
        public bool IsDamageable
        {
            get => _damageable;
            set => _damageable = value;
        }

        public virtual void Init(float health)
        {
            _health = health;
            _maxHealth = health;
            _damageable = true;
        }
        
        public void SetHealth(float health)
        {
            _health = health;
            if (_health <= 0)
            {
                Die();
            }
        }

        public void Kill()
        {
            SetHealth(0);   
        }

        public virtual void Die()
        {
            // Debug.Log($"[{gameObject.name}] Rat Died");
            _damageable = false;
            OnZeroHealth?.Invoke();
        }
        
        public virtual void TakeDamage(DamageArgs args)
        {
            var health = _health - args.amount;
            SetHealth(health);
        }

        public event Action<DamageArgs> OnDamaged;
    }
}