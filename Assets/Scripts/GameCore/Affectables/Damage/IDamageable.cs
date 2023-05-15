using System;

namespace GameCore.Affectables.Damage
{
    public interface IDamageable
    {
        bool IsDamageable { get; set; }
        void TakeDamage(DamageArgs args);
        event Action<DamageArgs> OnDamaged;
    }
}