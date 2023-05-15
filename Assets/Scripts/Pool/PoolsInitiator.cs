using Pool.Impls;
using UnityEngine;

namespace Pool
{
    public class PoolsInitiator : MonoBehaviour
    {
        public BulletsPool bulletsPool;

        private void Awake()
        {
            bulletsPool.Init();
            PoolsContainer.bulletsPool = bulletsPool;
        }
    }
}