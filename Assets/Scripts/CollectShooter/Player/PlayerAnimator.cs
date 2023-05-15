using CollectShooter.Animations;
using GameCore.Player;
using UnityEngine;

namespace CollectShooter.Player
{
    
    public class PlayerAnimator : MonoBehaviour
    {
        public Animator _animator;
        private PlayerEntity _entity;
        
        public void Init(PlayerEntity entity)
        {
            _entity = entity;
        }

        public void Kill(bool kill)
        {
            _animator.enabled = kill;
        }

        public void Idle()
        {
            _animator.CrossFade(AnimationHashes.Idle, AnimationConstants.MoveFadeDuration,0);
        }

        public void Run()
        {
            _animator.CrossFade(AnimationHashes.Run, AnimationConstants.MoveFadeDuration,0);
        }
        
        public void SetPause(bool paused)
        {
            _animator.speed = paused ? 0f : 1f;
        }
        
    }
}