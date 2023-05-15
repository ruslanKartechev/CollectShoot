using System.Collections;
using CollectShooter.Animations;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

namespace GameCore.Player
{
    public class CharacterMover : MonoBehaviour, ICharacterMover
    {
        private bool _isEnabled;
        private CharacterEntity _entity;
        
        private Coroutine _moving;
        private Coroutine _rotating;
        private Coroutine _speedChanging;

        private Vector3 _moveDirection;
        private float _speed;
        private bool _doRotateToMoveDirection;
        private bool _runningAnimation;

        public bool DoRotateToMoveDirection
        {
            get => _doRotateToMoveDirection;
            set
            {
                if (_doRotateToMoveDirection == value)
                    return;
                _doRotateToMoveDirection = value;
                if(_rotating != null)
                    StopCoroutine(_rotating);
                if (value)
                {
                    _moveDirection = _entity.movable.forward;
                    _rotating = StartCoroutine(RotatingToMoveDirection());
                }
            }
        }
        
        public bool IsEnabled
        {
            get => _isEnabled;
            set => _isEnabled = value;
        }
        
        
        public void Init(CharacterEntity entity)
        {
            _entity = entity;
            _moveDirection = _entity.movable.forward;
            DoRotateToMoveDirection = true;
        }

        public void MoveTo(Vector3 point)
        {
            StopMoving();
            _moveDirection = point - _entity.movable.position;
            _moving = StartCoroutine(MovingToPoint(point, GetMoveTime(point)));
        }

        public void RotateTo(Vector3 point)
        {
            StopRotation();
            var rotation = Quaternion.LookRotation(point - _entity.movable.position);
            var angle = Quaternion.Angle(rotation, _entity.rotatable.rotation);
            var time =  Mathf.Abs(angle / _entity.movementSettings.rotationSpeed);
            _rotating = StartCoroutine(RotatingTo( rotation, time));
        }
        
        
        public void StopAll()
        {
            StopBoth();
        }

        public void SetMoveDirection(Vector3 direction) => _moveDirection = direction;
        
        public void MoveDir(Vector3 direction)
        {
            _moveDirection = direction;
            // Debug.Log($"speed: {_speed}");
            _entity.movable.position += direction.normalized * _speed * Time.deltaTime;
            SetAnimationState(true);
        }

        public void RotateDir(bool right)
        {
            _entity.rotatable.Rotate(_entity.rotatable.up, 
                _entity.movementSettings.rotationSpeed, 
                Space.Self);
        }

        public void Idle()
        {
            _moveDirection = _entity.movable.forward;
            SetAnimationState(false);
        }
        
        public void SetAnimationState(bool running)
        {
            if (running == _runningAnimation)
                return;
            _runningAnimation = running;
            if (_runningAnimation)
            {
                ChangeSpeed(0f, 
                    _entity.movementSettings.moveSpeed,
                    AnimationConstants.MoveFadeDuration * 1.5f);
                _entity.playerAnimator.Run();
                
            }
            else
            {
                _entity.playerAnimator.Idle();
                _speed = 0;
            }
        }
        
        public void ChangeSpeed(float from, float to, float time)
        {
            if(_speedChanging != null)
                StopCoroutine(_speedChanging);
            _speedChanging = StartCoroutine(SpeedChange(from, to, time));
        }
        
        

        private float GetMoveTime(Vector3 point)
        {
            return (point - _entity.movable.position).magnitude / _entity.movementSettings.moveSpeed;
        }
        
        
        private void StopMoving()
        {
            if(_moving != null)
                StopCoroutine(_moving);
    
        }

        private void StopRotation()
        {
            if(_rotating != null)
                StopCoroutine(_rotating);
        }

        private void StopBoth()
        {
            StopMoving();
            StopRotation();
            _doRotateToMoveDirection = false;
        }

        private IEnumerator MovingToPoint(Vector3 point, float time)
        {
            var elapsed = 0f;
            var start = _entity.movable.position;
            while (elapsed < time)
            {
                _entity.movable.position = Vector3.Lerp(start, point, elapsed / time);
                elapsed += Time.deltaTime;  
                yield return null;
            }
            _entity.movable.position = point;
        }

        private IEnumerator RotatingTo(Quaternion endRot, float time)
        {
            var elapsed = 0f;
            var start = _entity.rotatable.rotation;
            while (elapsed < time)
            {
                _entity.movable.rotation = Quaternion.Lerp(start, endRot, elapsed / time);
                elapsed += Time.deltaTime;  
                yield return null;
            }
            _entity.movable.rotation = endRot;
        }


        private IEnumerator RotatingToMoveDirection()
        {
            while (true)
            {
                _entity.rotatable.rotation = Quaternion.Lerp(_entity.rotatable.rotation,
                    Quaternion.LookRotation(_moveDirection),
                    _entity.movementSettings.lerpMoveSpeed);
                yield return null;
            }
        }

        
        private IEnumerator SpeedChange(float from, float to, float time)
        {
            var elapsed = 0f;
            while (elapsed < time)
            {
                _speed = Mathf.Lerp(from, to, elapsed / time);
                elapsed += Time.deltaTime;
                yield return null;
            }
            _speed = to;
        }
        
    }
}