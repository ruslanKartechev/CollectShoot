
using UnityEngine;

namespace GameCore.Levels
{
    public abstract class Level : MonoBehaviour
    {
        public abstract void Init();
        public abstract void StartLevel();
        public abstract void Win();
        public abstract void Loose();
        public abstract void Unload();
    }
}