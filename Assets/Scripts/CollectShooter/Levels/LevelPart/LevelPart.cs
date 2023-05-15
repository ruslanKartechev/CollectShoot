using CollectShooter.Collectables;
using CollectShooter.NPC;
using GameCore.Data;
using UnityEngine;

namespace CollectShooter.Levels.LevelPart
{
    public class LevelPart : MonoBehaviour
    {
        public CollectablesManager collectablesManager;
        public BlockNpcManager NpcManager;

        public void Init()
        {
            NpcManager.Spawn();
        }

        public void Activate()
        {
            LevelContainer.collectablesManager = collectablesManager;
            NpcManager.Activate();
        }

    }
}