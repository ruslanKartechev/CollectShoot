using UnityEngine;

namespace GameCore.Player
{
    public abstract class CharacterBehaviour : MonoBehaviour
    {
        public abstract void Init(CharacterEntity entity);
        public abstract void Activate();
        public abstract void Stop();
    }
}