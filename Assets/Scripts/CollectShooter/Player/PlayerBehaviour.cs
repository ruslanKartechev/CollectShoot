using System.Collections;
using CollectShooter.Weapons;
using GameCore.Data;
using GameCore.Player;
using GameCore.Servises.Spawning;
using UnityEngine;

namespace CollectShooter.Player
{
    public class PlayerBehaviour : CharacterBehaviour, IWeaponUser
    {
        private PlayerEntity _entity;
        
        public override void Init(CharacterEntity entity)
        {
            _entity = (PlayerEntity)entity;
            _entity.mover.Init(_entity);
            SpawnModel();
            _entity.camPoint.Init();
            _entity.backpack.Init(_entity);
        }

        private void SpawnModel()
        {
            var modelPrefab =  GlobalContainer.PlayerModelsRepository.GetFirst();
            var instance = GlobalContainer.SpawnService.SpawnFor<PlayerModel>(new SpawnArgs()
            {
                Parent = _entity.modelSpawn,
                Position =  _entity.modelSpawn.position,
                Rotation = _entity.modelSpawn.rotation,
                Prefab = modelPrefab
            });
            instance.Init(_entity);
        }

        
        public override void Activate()
        {
            UIContainer.ControlsUI.IsEnabled = true;
            SubMovement();
            _entity.mover.DoRotateToMoveDirection = true;
            _entity.backpack.Activate(true);   
        }

        public override void Stop()
        {
            UIContainer.ControlsUI.IsEnabled = false;
            UnSubMovement();
        }


        #region Loading

        private IWeapon _weapon;
        private bool _isGiving;
        private Coroutine _givingItems;

        public Team GetTeam() => _entity.Team;
        
        private void OnTriggerStay(Collider other)
        {
            if (_isMoving)
                return;
            if (other.CompareTag(Tags.Weapon))
            {
                if (_weapon == null)
                    _weapon = other.GetComponent<IWeapon>();

                if (_weapon != null && !_isGiving)
                {
                    BeginGiving();
                }
            }
        }

        private void BeginGiving()
        {
            StopGiving();
            if (CheckGiveCondition() == false)
                return;
            _isGiving = true;
            _givingItems = StartCoroutine(GivingItems());
            _entity.mover.SetMoveDirection((_weapon.LookAtPosition() - _entity.movable.position));
        }

        private void StopGiving()
        {
            _isGiving = false;
            if(_givingItems != null)
                StopCoroutine(_givingItems);
            // Dbg.Red("STOPPED giving items");
        }

        private IEnumerator GivingItems()
        {
            var bp = _entity.backpack;
            while (CheckGiveCondition())
            {
                var item = bp.PullItem();
                _weapon.TakeItem(item, this);
                yield return new WaitForSeconds(_entity.backpackSettings.ItemPullDelay);
            }
            _isGiving = false;
        }

        private bool CheckGiveCondition() => _entity.backpack.Count > 0 && _weapon.CanTake();
        #endregion

        
        #region  Moving

        private bool _isMoving;
        public void SubMovement()
        {
            GlobalContainer.InputManager.OnClick += OnClick;
            GlobalContainer.InputManager.OnRelease += OnRelease;
            GlobalContainer.InputManager.OnMoved += OnMoved;
            if(Input.GetMouseButton(0))
                OnClick(Input.mousePosition);
        }

        public void UnSubMovement()
        {
            GlobalContainer.InputManager.OnClick -= OnClick;
            GlobalContainer.InputManager.OnRelease -= OnRelease;
            GlobalContainer.InputManager.OnMoved -= OnMoved;
            OnRelease(Vector3.zero);
        }
        
        private void OnClick(Vector3 pos)
        {
            _isMoving = true;
            StopGiving();
            _entity.mover.DoRotateToMoveDirection = true;
            UIContainer.ControlsUI.OnClick(pos);
        }

        private void OnRelease(Vector3 pos)
        {
            UIContainer.ControlsUI.OnRelease(pos);
            _entity.mover.Idle();
            _isMoving = false;
        }
        
        private void OnMoved(Vector3 dir)
        {
            var calculated = UIContainer.ControlsUI.CalculateMove(dir);
            var joystickPos = UIContainer.ControlsUI.MoveUI(calculated);
            if (joystickPos == Vector3.zero)
                return;
            var moveDir = new Vector3(joystickPos.x, 0, joystickPos.y);
            moveDir = GlobalContainer.CameraTransform.TransformPoint(moveDir);
            moveDir.y = 0f;
            _entity.mover.MoveDir(moveDir);
        }
        #endregion

    
    }
    
}