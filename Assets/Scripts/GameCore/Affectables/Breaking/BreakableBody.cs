using System.Collections;
using System.Collections.Generic;
using GameCore.Utils;
using UnityEngine;

namespace GameCore.Affectables.Breaking
{
    public partial class BreakableBody : MonoBehaviour
    {
        public bool hideBroken;
        public float hideBrokenDelay = 5;
        public float defaultBreakForce;
        public ForceMode defaultForceMode = ForceMode.Impulse;
        [Space(10)] 
        public Transform root;
        public Transform centerPosition;
        public List<BreakPart> parts;

        public void SetActive(bool active, bool visible = true)
        {
            foreach (var p in parts)
            {
                if(visible)
                    p.SetActiveVisible(active);
                else
                    p.SetActive(active);
            }   
        }
        
        
        public void GetParts()
        {
            parts?.Clear();
            parts = new List<BreakPart>();
            var count = root.childCount;
            for (int i = 0; i < count; i++)
            {
                var go = root.GetChild(i).gameObject;
                if(centerPosition != null && go.transform == centerPosition)
                    continue;
                var rb = go.GetOrAdd<Rigidbody>();
                var coll = go.GetOrAdd<Collider, BoxCollider>();
                var part = new BreakPart(go, rb, coll);
                parts.Add(part);
            }
        }

        public void ClearNulls()
        {
            for (int i = parts.Count - 1; i >= 0; i--)
            {
                if (parts[i].go == null)
                    parts.RemoveAt(i);
            }
        }
        
        public void ClearAll(bool removeRbAndColl)
        {
            for (int i = parts.Count - 1; i >= 0; i--)
            {
                if (removeRbAndColl)
                    parts[i].RemoveRbAndColl();
                parts.RemoveAt(i);
            }
        }
        
        public void BreakDefault(Vector3 direction, ForceMode mode = ForceMode.Impulse)
        {
            BreakAllParts(defaultBreakForce, direction, mode);
        }
        
        public void BreakAllParts(float force, Vector3 direction, ForceMode mode = ForceMode.Impulse)
        {
            foreach (var p in parts)
            {
                p.Push(force * direction, mode);
            }   
            Hide();
        }

        public void BreakFromCenterDefault()
        {
            BreakAllPartsFromCenter(defaultBreakForce, defaultForceMode);
        }
        
        public void BreakAllPartsFromCenter(float force, ForceMode mode = ForceMode.Impulse)
        {
            foreach (var p in parts)
            {
                var forceVector = (p.go.transform.position - centerPosition.position).normalized * force;
                p.Push(forceVector, mode);
            }
            Hide();
        }

        public void Hide()
        {
            if (!hideBroken)
                return;
            StartCoroutine(DelayedHide());
        }

        private IEnumerator DelayedHide()
        {
            yield return new WaitForSeconds(hideBrokenDelay);
            foreach (var p in parts)
            {
                p.Hide();
            }
        }
    }
}