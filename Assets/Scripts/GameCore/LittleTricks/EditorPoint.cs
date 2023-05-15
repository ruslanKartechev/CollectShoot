using UnityEngine;

namespace GameCore.LittleTricks
{
    public class EditorPoint : MonoBehaviour
    {
        public bool doDraw = true;
        public Color color = Color.green;
        public float rad = 1f;

        private void OnDrawGizmos()
        {
            if (!doDraw)
                return;
            Gizmos.color = color;
            Gizmos.DrawSphere(transform.position, rad);
        }
    }
}