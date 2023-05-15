using System;
using LabShoot.Player;
namespace GameCore.Player
{
    public class PlayerEntity : CharacterEntity
    {
        public CharacterBehaviour behaviour;
        public CharacterMover mover;

        [NonSerialized] public PlayerCameraPoint camPoint;

    }
}