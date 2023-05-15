using GameCore.LittleTricks;
using UnityEngine;

namespace CollectShooter.NPC
{
    public class RivalNpcSpawnPoint : EditorPoint
    {
        public RivalNpcEntity prefab;
        
        public RivalNpcEntity Spawn(Transform parent)
        {
            var instance = Instantiate(prefab, parent);
            var tr = instance.transform;
            tr.position = transform.position;
            tr.rotation = transform.rotation;
            instance.behaviour.Init(instance);
            return instance;
        }

    }
}