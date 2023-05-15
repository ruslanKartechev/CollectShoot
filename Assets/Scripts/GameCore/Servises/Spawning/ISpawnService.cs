using UnityEngine;

namespace GameCore.Servises.Spawning
{
    public interface ISpawnService
    {
        Transform DefaultParent { get; }
        GameObject SpawnGameObject(SpawnArgs args);
        T SpawnFor<T>(SpawnArgs args);
        
    }
}