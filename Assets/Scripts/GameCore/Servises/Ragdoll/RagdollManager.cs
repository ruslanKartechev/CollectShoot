using System.Collections.Generic;
using GameCore.Utils;
using UnityEngine;

namespace GameCore.Servises.Ragdoll
{
    public class RagdollManager : RagdollManagerBase
    {
        [System.Serializable]
        public class RagdollPart
        {
            public Collider collider;
            public Rigidbody rb;
            public bool push;
            public string name;

            public void Off()
            {
                rb.isKinematic = true;
                collider.enabled = false;
            }

            public void On()
            {
                rb.isKinematic = false;
                collider.enabled = true;
            }

            public void Push(Vector3 force)
            {
                rb.AddForce(force, ForceMode.Impulse);
            }
        }

        public List<RagdollPart> parts;
        public override bool IsActive { get; protected set; }
        public override void Activate()
        {
            foreach (var part in parts)
            {
                part.On();
            }   
        }

        public override void Deactivate()
        {
            foreach (var part in parts)
            {
                part.Off();
            }   
        }

        public override void ActivateAndPush(Vector3 force)
        {
            var pushable = new List<RagdollPart>();
            foreach (var part in parts)
            {
                part.On();
                part.rb.velocity = Vector3.zero;
                if(part.push)
                    pushable.Add(part);
            }
            foreach (var part in pushable)
            {
                part.rb.velocity = Vector3.zero;
                part.Push(force);
            }
        }
        
        
        #if UNITY_EDITOR
        public void GetAllParts()
        {
            List<Transform> gos = HierarchyHelpers.GetFromAllChildren<Transform>(transform, (go) =>
            {
                if (go == transform)
                    return false;
                var coll = go.GetComponent<Collider>();
                var rb = go.GetComponent<Rigidbody>();
                if (rb != null)
                    return true;
                return false;
            });
            parts = new List<RagdollPart>();
            foreach (var go in gos)
            {
                var part = new RagdollPart()
                {
                    rb = go.GetComponent<Rigidbody>(),
                    collider =  go.GetComponent<Collider>(),
                    name = go.name
                };
                if (part.collider == null)
                {
                    Debug.Log($"!!!!!! COLLIDER IS NULL on : {part.name}");
                }
                parts.Add(part);
            }
        }
        
        public void SetAllInterpolate()
        {
            foreach (var part in parts)
            {
                part.rb.interpolation = RigidbodyInterpolation.Interpolate;
            }
        }

        public void SetAllNoInterpolate()
        {
            foreach (var part in parts)
            {
                part.rb.interpolation = RigidbodyInterpolation.None;
            }
        }
        
        public void SetProjection()
        {
            foreach (var part in parts)
            {
                var joint = part.rb.GetComponent<CharacterJoint>();
                if(joint == null)
                    continue;
                joint.enableProjection = true;
            }
        }

        public void SetNoProjection()
        {
            foreach (var part in parts)
            {
                var joint = part.rb.GetComponent<CharacterJoint>();
                if(joint == null)
                    continue;
                joint.enableProjection = false;
            }
        }
        
        public void SetAllPreprocess(bool preprocess)
        {
            foreach (var part in parts)
            {
                var joint = part.rb.gameObject.GetComponent<Joint>();
                if(joint != null)
                    joint.enablePreprocessing = preprocess;
            }
        }
        
        #endif

      
    }
}