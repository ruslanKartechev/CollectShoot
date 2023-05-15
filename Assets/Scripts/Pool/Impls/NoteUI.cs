using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Pool
{
    public class NoteUI : MonoBehaviour, IPooledObject<NoteUI>
    {
        [SerializeField] private Transform _moveTarget;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _image;
        [SerializeField] [Range(0f,1f)] private float _endPosWidthPortion;
        [SerializeField] [Range(0f,1f)] private float _endPosHeightPortion;
        private IPool<NoteUI> _pool;

        public void FlyTo(Vector3 startPosition, Vector3 endPosition, float time, Sprite noteSprite, string noteName, Action onEnd)
        {
            _image.sprite = noteSprite;
            _text.text = noteName;
            Reset();
            transform.position = startPosition;
            transform.DOMove(endPosition, time).OnComplete(() => 
            { 
                onEnd.Invoke();
            } ).SetEase(Ease.InExpo);
        }

        private void Reset()
        {
            _moveTarget.position = Vector3.zero;
            gameObject.SetActive(true);
        }

        public void Init(IPool<NoteUI> pool)
        {
            _pool = pool;
            gameObject.SetActive(false);
        }

        public void ReturnSelf()
        {
            CollectBack();
            _pool.Return(this);
        }

        public void CollectBack()
        {
            _moveTarget.DOKill();
            gameObject.SetActive(false);
        }
    }
}