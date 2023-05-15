using CollectShooter.Player;
using UnityEngine;
using GameCore.Player;

namespace LabShoot.Player
{
    public class MainPlayerModel : PlayerModel
    {
        [SerializeField] private PlayerCameraPoint _camPoint;
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private Transform _backpackPosition;
        private PlayerEntity _player;
        
        public override void Init(PlayerEntity player)
        {
            _player = player;
            _player.camPoint = _camPoint;
            _player.playerAnimator = _animator;
            _animator.Init(_player);
            _player.packParent = _player.packStartPosition = _backpackPosition;
        }
    }
}