using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace GameCore.GameUI.ProgressBar
{
    public class SimpleProgressBar : MonoBehaviour
    {
        public float ChangeTime = 0.2f;
        public Image fillImage;
        protected float _val;
        protected Coroutine _filling;
        
        public void SetValue(float value)
        {
            _val = value;
            fillImage.fillAmount = value;
        }

        public void ChangeValue(float newValue)
        {
            Stop();
            _filling = StartCoroutine(Filling(_val, newValue, ChangeTime));
            _val = newValue;
        }

        public void Stop()
        {
            if(_filling != null)
                StopCoroutine(_filling);
        }

        public IEnumerator Filling(float startVal, float endValue, float duration)
        {
            var elapsed = 0f;
            while (elapsed < duration)
            {
                var val = Mathf.Lerp(startVal, endValue, elapsed / duration);
                fillImage.fillAmount = val;
                elapsed += Time.deltaTime;
                yield return null;
            }
            fillImage.fillAmount = endValue;
        }
    }
}