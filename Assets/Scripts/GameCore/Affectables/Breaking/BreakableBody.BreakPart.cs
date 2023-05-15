using UnityEngine;

namespace GameCore.Affectables.Breaking
{
    public partial class BreakableBody
    {
        [System.Serializable]
        public class BreakPart
        {
            public BreakPart(GameObject go, Rigidbody rb, Collider coll)
            {
                this.go = go;
                this.rb = rb;
                this.coll = coll;
            }

            public GameObject go;
            public Rigidbody rb;
            public Collider coll;
            
            
            public void SetActive(bool active)
            {
                go.SetActive(active);
                rb.isKinematic = !active;
                coll.enabled = active;
            }

            public void SetActiveVisible(bool active)
            {
                rb.isKinematic = !active;
                coll.enabled = active;   
            }

            public void Push(Vector3 force, ForceMode mode)
            {
                SetActive(true);
                rb.AddForce(force,mode);
            }

            public void RemoveRbAndColl()
            {
                if(rb != null)
                    DestroyImmediate(rb);
                if(coll != null)
                    DestroyImmediate(coll);
            }

            public void Hide()
            {
                go.SetActive(false);
            }
        }
    }
}