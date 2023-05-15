using System;

namespace GameCore.Stats.Health
{
    public interface IHealth
    {
        public event Action OnZeroHealth;
        public void Init(float health);
        public float CurrentHealth { get; }
        public void SetHealth(float health);
        public void Kill();
    }
}