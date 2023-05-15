using UnityEngine;

namespace GameCore.Servises.Ragdoll
{
    public abstract class RagdollManagerBase : MonoBehaviour
    {
        public abstract void Deactivate();
        public abstract void Activate();
        public abstract void ActivateAndPush(Vector3 force);
        public abstract bool IsActive { get; protected set; }

    }
}