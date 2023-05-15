using UnityEngine;

namespace GameCore.Player
{
    public interface ICharacterMover
    {
        bool IsEnabled { get; set; }
        void Init(CharacterEntity entity);
        void MoveTo(Vector3 point);
        void RotateTo(Vector3 point);
        void StopAll();
        void MoveDir(Vector3 direction);
        void RotateDir(bool right);
        
    }
}