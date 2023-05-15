using DG.Tweening;
using GameCore.Data;
using Pool;
using UnityEngine;

namespace GameCore.Usables.Bullets
{
    public class TweenPooledBullet : PooledBulletBase
    {
        public Ease moveEase;
        public ParticleSystem explodeParticles;

        public override void Init(IPool<PooledBulletBase> pool)
        {
            base.Init(pool);
            explodeParticles.transform.SetParent(transform.parent);
        }
        
        public override void CollectBack()
        {
            transform.DOKill();
            gameObject.SetActive(false);
        }

        public override void ShootAt(BulletShootArgs args)
        {
            transform.DOKill();
            transform.position = args.from;
            transform.rotation = args.Rotation;
            gameObject.SetActive(true);
            var time = (transform.position - args.to).magnitude / Velocity;
            transform.DOMove(args.to, time).SetEase(moveEase).OnComplete(() =>
            {
                if(args.willDamage)
                    ReturnSelf();
                else
                    OnArrived();
                args.onMoved.Invoke();
            });
            gameObject.layer = args.bulletLayer;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.layer = args.bulletLayer;
            }
        }

        protected virtual void OnArrived()
        {
            explodeParticles.transform.position = transform.position;
            explodeParticles.Play();
            ReturnSelf();
        }
    }
}