using UnityEngine;

namespace GameCore.Servises.Spawning
{
    public interface IParentService
    {
        Transform DefaultParent { get; set; }
    }
}