using DG.Tweening;
using Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.GameUI.Additional
{
    public class MoneyUISplash : MonoBehaviour, IPooledObject<MoneyUISplash>
    {
        [SerializeField] private Transform _moveTarget;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private float _endAlpha;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _image;
        [SerializeField] private float _duration;
        [SerializeField] [Range(0f,1f)] private float _endPosWidthPortion;
        [SerializeField] [Range(0f,1f)] private float _endPosHeightPortion;
        
        private IPool<MoneyUISplash> _pool;

        public void StartAt(Vector2 screenPosition, int addedCount)
        {
            Reset();
            transform.position = screenPosition;
            _text.text = $"+{addedCount}";
            _image.DOFade(_endAlpha, _fadeDuration);
            _text.DOFade(_endAlpha, _fadeDuration);
            var endPos = new Vector2(Screen.width * _endPosWidthPortion, Screen.height * _endPosHeightPortion);
            transform.DOMove(endPos, _duration).OnComplete(() => { 
                gameObject.SetActive(false); 
                _pool.Return(this); } ).SetEase(Ease.InExpo);
        }

        private void Reset()
        {
            var color = _image.color;
            color.a = 1f;
            _image.color = color;
            _image.DOKill();
            _text.DOKill();
            var c= _text.color;
            c.a = 1f;
            _text.color = c;   
            _moveTarget.localPosition = Vector3.zero;
            gameObject.SetActive(true);
        }

        public void Init(IPool<MoneyUISplash> pool)
        {
            _pool = pool;
            gameObject.SetActive(false);
        }

        public void CollectBack()
        {
            _moveTarget.DOKill();
            _image.DOKill();
            _text.DOKill();
            gameObject.SetActive(false);
        }
    }
}