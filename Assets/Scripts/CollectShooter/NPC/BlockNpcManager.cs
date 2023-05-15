using UnityEngine;

namespace CollectShooter.NPC
{
    public class BlockNpcManager : MonoBehaviour
    {
        public NpcSpawner spawner;
        public void Spawn()
        {
            spawner.SpawnAll();
        }

        public void Activate()
        {
            var entities = spawner.spawned;
            foreach (var entity in entities)
            {
                entity.behaviour.Activate();
            }
        }

        public void HideAll()
        {
            var entities = spawner.spawned;
            foreach (var entity in entities)
            {
                entity.behaviour.Stop();
                entity.gameObject.SetActive(false);
            }
        }
    }
}