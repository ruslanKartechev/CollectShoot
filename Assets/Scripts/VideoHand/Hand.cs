using System;
using System.Collections;
using DG.Tweening;
using GameCore.Data;
using UnityEngine;

namespace VideoHand
{
    public class Hand : MonoBehaviour
    {
        public float scaleTime;
        public float downSale;
        public float normalScale;
        [Space(10)] 
        public Transform handTarget;
        public MainConfig config;
        private Coroutine _working;
        private Tween _handTween;
        
        private void OnEnable()
        {
            if (config.UseHand)
            {
                Enable();
            }
            else
            {
                Disable();
            }
        }

        public void Enable()
        {
            Disable();
            _working = StartCoroutine(Working());
        }

        public void Disable()
        {
            if(_working != null)
                StopCoroutine(_working);
            handTarget.gameObject.SetActive(false);
        }

        private IEnumerator Working()
        {
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ShowAt(Input.mousePosition);
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    Hide();
                }
                
                if (Input.GetMouseButton(0))
                {
                    handTarget.transform.position = Input.mousePosition;
                }
                yield return null;
            }
        }


        private void ShowAt(Vector2 pos)
        {
            _handTween?.Kill();
            handTarget.localScale = Vector3.one * normalScale;
            handTarget.transform.position = pos;
            handTarget.gameObject.SetActive(true);
            _handTween = handTarget.DOScale(Vector3.one * downSale, scaleTime)
                .OnComplete(() =>
                {
                });
        }

        private void Hide()
        {
            _handTween?.Kill();
            _handTween = handTarget.DOScale(Vector3.one * normalScale, scaleTime)
                .OnComplete(() =>
                {
                    handTarget.gameObject.SetActive(false);
                });      
        }
        
    }
}