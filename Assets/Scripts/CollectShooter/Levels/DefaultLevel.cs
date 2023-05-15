using CollectShooter.Collectables;
using CollectShooter.Levels.LevelPart;
using GameCore.Data;
using GameCore.Levels;
using UnityEngine;

namespace CollectShooter.Levels
{
    public class DefaultLevel : Level
    {
        public PlayerSpawner playerSpawner;
        public LevelPartsManager partsManager;
        public CollectablesManager collectablesManager;
        
        public override void Init()
        {
            GlobalContainer.CollectablesManager = collectablesManager;
            LevelContainer.level = this;
            playerSpawner.Spawn();
            
            UIContainer.UIManager.ShowStart();
            partsManager.Init();
        }

        public override void StartLevel()
        {
            Debug.Log($"[Level] activated");
            GlobalContainer.InputManager.IsEnabled = true;
            UIContainer.UIManager.ShowProgress();            
            LevelContainer.player.behaviour.Activate();
            partsManager.ActivateFirst();

        }

        public override void Win()
        {
            Stop();
        }

        public override void Loose()
        {
            Stop();
        }

        public void Stop()
        {
            GlobalContainer.InputManager.IsEnabled = false;
            LevelContainer.player.behaviour.Stop();
        }

        public override void Unload()
        {
               
        }
        
        
        
    }
}