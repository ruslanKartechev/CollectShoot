using GameCore.Player;

namespace CollectShooter.NPC
{
    public class RivalNpcEntity : CharacterEntity
    {
        public NpcBehaviourSettings behaviourSettings;
        public RivalNpcBehaviour behaviour;
        public CharacterMover mover;
    }
}