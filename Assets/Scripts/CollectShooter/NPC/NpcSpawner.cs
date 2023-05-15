using System.Collections.Generic;
using UnityEngine;

namespace CollectShooter.NPC
{
    public class NpcSpawner : MonoBehaviour
    {
        public Transform parent;
        public List<RivalNpcSpawnPoint> spawnPoints;
        public List<RivalNpcEntity> spawned;
        
        public void SpawnAll()
        {
            foreach (var p in spawnPoints)
            {
                spawned.Add(p.Spawn(parent));   
            }
        }
    }
}