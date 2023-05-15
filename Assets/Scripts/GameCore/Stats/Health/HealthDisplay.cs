using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Stats.Health
{
    public class HealthDisplay : MonoBehaviour
    {
        private const float ScaleUp = 1.25f;
        private const float ScaleDown = 0.6f;
        private const float ScaleTime = 0.2f;

        public Vector3 localEulers;
        public Vector3 localPosition;
        public Transform scalable;
        public Image fillImage;
        
        public void InitPosition(Transform parent)
        {
            var tr = transform;
            tr.parent = parent;
            tr.localRotation = Quaternion.Euler(localEulers);
            tr.localPosition = localPosition;
        }
        
        public void SetValue(float value)
        {
            fillImage.fillAmount = value;
        }

        public void Show(bool animated = true)
        {
            gameObject.SetActive(true);
            if (animated)
            {
                scalable.localScale = new Vector3(1, 0f, 1f);
                scalable.DOScale(Vector3.one, ScaleTime);
            }
        }

        public void Hide(bool animated = false)
        {
            gameObject.SetActive(false);
        }
        
        public void UpdateUp(float value)
        {
            fillImage.fillAmount = value;
            scalable.localScale = Vector3.one * ScaleUp;
            scalable.DOScale(Vector3.one , ScaleTime);
        }
        
        public void UpdateDown(float value)
        {
            fillImage.fillAmount = value;
            scalable.localScale = Vector3.one * ScaleDown ;
            scalable.DOScale(Vector3.one , ScaleTime);
        }
        
        public void UpdateValue(float value)
        {
            fillImage.fillAmount = value;
        }
        
    }
}