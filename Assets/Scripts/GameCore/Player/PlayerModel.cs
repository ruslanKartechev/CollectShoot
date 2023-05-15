using UnityEngine;

namespace GameCore.Player
{
    public abstract class PlayerModel : MonoBehaviour
    {
        public abstract void Init(PlayerEntity player);
    }
}