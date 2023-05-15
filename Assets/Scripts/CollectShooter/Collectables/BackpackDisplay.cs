using DG.Tweening;
using TMPro;
using UnityEngine;

namespace CollectShooter.Collectables
{
    public class BackpackDisplay : MonoBehaviour
    {
        private const float ScaleUp = 1.25f;
        private const float ScaleDown = 0.6f;
        private const float ScaleTime = 0.2f;
        private const float ScaleFactor = 1f/100;

        public Vector3 localEulers;
        public Vector3 localPosition;
        public Transform scalable;
        public TextMeshPro text;
        public void InitPosition(Transform parent)
        {
            var tr = transform;
            tr.parent = parent;
            tr.localRotation = Quaternion.Euler(localEulers);
            tr.localPosition = localPosition;
        }
        
        public void SetCount(int count, int max)
        {
            text.text = $"{count}/{max}";
        }

        public void Show(bool show)
        {
            gameObject.SetActive(show);
        }

        
        public void UpdateCountUp(int count, int max)
        {
            SetCount(count, max);
            scalable.localScale = Vector3.one * ScaleUp ;
            scalable.DOScale(Vector3.one , ScaleTime);
        }
        
        public void UpdateCountDown(int count, int max)
        {
            SetCount(count, max);
            scalable.localScale = Vector3.one * ScaleDown ;
            scalable.DOScale(Vector3.one , ScaleTime);
        }
    }
    
    
}