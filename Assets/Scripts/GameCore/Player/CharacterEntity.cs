using CollectShooter.Collectables;
using CollectShooter.Player;
using CollectShooter.Teams;
using UnityEngine;

namespace GameCore.Player
{
    public class CharacterEntity : MonoBehaviour
    {
        public Transform modelSpawn;
        public Transform rotatable;
        public Transform movable;
        public CharacterMovementSettings movementSettings; 
        public PlayerAnimator playerAnimator;

        public Team Team;
        // backpack
        public Backpack backpack;
        public BackpackSettings backpackSettings;
        public BackpackDisplay backpackDisplay;
        public Transform packParent;
        public Transform packStartPosition;
        //
        
    }
}