using GameCore.Data;
using GameCore.Player;
using GameCore.Servises.Spawning;
using UnityEngine;

namespace CollectShooter.Levels
{
    [System.Serializable]
    public class PlayerSpawner
    {
        public Transform spawn;
        public PlayerEntity prefab;
        public Team playerTeam;
        
        public void Spawn()
        {
            var instance = GlobalContainer.SpawnService.SpawnFor<PlayerEntity>(new SpawnArgs()
            {
                Parent = spawn,
                Prefab = prefab,
                Position = spawn.position,
                Rotation = spawn.rotation
            });
            instance.Team = playerTeam;
            LevelContainer.player = instance;
            instance.behaviour.Init(instance);
        }
    }
}