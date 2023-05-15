using Pool;
using UnityEngine;

namespace GameCore.Usables.Bullets
{
    public abstract class PooledBulletBase : MonoBehaviour, IBullet, IPooledObject<PooledBulletBase>
    {
        protected IPool<PooledBulletBase> _pool;
        
        public float Velocity { get; set; }
        public float Damage { get; set; }

        public virtual void Init(IPool<PooledBulletBase> pool)
        {
            _pool = pool;
        }

        public abstract void CollectBack();

        public abstract void ShootAt(BulletShootArgs args);

        public virtual void ReturnSelf()
        {
            CollectBack();
            _pool.Return(this);
        }

    }
}