using DG.Tweening;
using GameCore.Stats.Money;
using TMPro;
using UnityEngine;

namespace GameCore.GameUI.Additional
{
    public class MoneyUI : MonoBehaviour, IMoneyUI
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Transform _scaleTarget;
        [SerializeField] private float _smallScale;
        [SerializeField] private float _scaleTime;
        [SerializeField] private int _wrongPulses = 3;
        [SerializeField] private float _wrongScaleTime = 0.2f;
        private Sequence _scaling;
        private bool _inited;
        
        public void Init()
        {
            if (!_inited)
            {
               MoneyCounter.TotalMoney.SubOnChange(UpdateCount);
                _inited = true;
            }
            SetCount();
        }
        
        public void Animate()
        {
            _scaling?.Kill();
            _scaling = DOTween.Sequence();
            transform.localScale = Vector3.one;
            _scaling.Append(_scaleTarget.DOScale(Vector3.one * _smallScale, _scaleTime).SetEase(Ease.InBack)
            ).Append(_scaleTarget.DOScale(Vector3.one * 1f, _scaleTime).SetEase(Ease.InBack));
        }
        
        public void AnimateWrong()
        {
            _scaling?.Kill();
            _scaling = DOTween.Sequence();
            transform.localScale = Vector3.one;
            _scaling.Append(_scaleTarget.DOScale(Vector3.one * _smallScale, _wrongScaleTime).SetEase(Ease.InBack)
            ).Append(_scaleTarget.DOScale(Vector3.one * 1f, _wrongScaleTime).SetEase(Ease.InBack))
                .SetLoops(_wrongPulses);
        }
        
        public void UpdateCount()
        {
            SetCount();
            Animate();
        }
        
        public void UpdateCount(int count)
        {
            SetCount();
            Animate();
        }
        
        public void SetCount()
        {
            _text.text = $"{MoneyCounter.TotalMoney.Value}";
        }

        public void Hide()
        {
            MoneyCounter.TotalMoney.UnsubOnChange(UpdateCount);
            _inited = false;
            gameObject.SetActive(false);
        }
    }
}