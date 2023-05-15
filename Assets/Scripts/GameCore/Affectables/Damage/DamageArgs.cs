using UnityEngine;

namespace GameCore.Affectables.Damage
{
    public struct DamageArgs
    {
        public float amount;
        public Vector3 direction;

        public DamageArgs(float amount, Vector3 direction)
        {
            this.amount = amount;
            this.direction = direction;
        }
    }
}