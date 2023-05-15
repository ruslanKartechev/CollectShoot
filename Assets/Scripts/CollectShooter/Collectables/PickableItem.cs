using UnityEngine;

namespace CollectShooter.Collectables
{
    public class PickableItem : MonoBehaviour
    {
        public bool IsPickable { get; set; }
        public Vector3 Position => transform.position;
    }
}