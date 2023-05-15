using UnityEngine;

namespace GameCore.Player
{
    [CreateAssetMenu(fileName = nameof(CharacterMovementSettings), menuName = "SO/" + nameof(CharacterMovementSettings))]
    public class CharacterMovementSettings : ScriptableObject
    {
        public float moveSpeed;
        public float rotationSpeed;
        public float lerpMoveSpeed;
    }
}