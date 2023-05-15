using System;
using System.Collections.Generic;
using GameCore.Data;
using GameCore.LittleTricks;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.GameUI.Pages
{
    public class WinPage : UIPageWithButton, IWinPage
    {
        [SerializeField] private List<PulsingAnimator> _animators;
        private Coroutine _delayedMoneySent;

        private void OnValidate()
        {
            if (_canvas == null)
            {
                _canvas = GetComponent<Canvas>();
                _canvas.overrideSorting = true;
                _canvas.sortingOrder = 1;
            }
            if (_raycaster == null)
                _raycaster = GetComponent<GraphicRaycaster>();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public override void Open(bool animated)
        {
            base.Open(animated);
            // _button.onClick.AddListener(OnClick);
            // _button.interactable = true;
        }

        public override void Close(bool animated)
        {
            base.Close(animated);
            // _button.onClick.RemoveListener(OnClick);
            // _button.interactable = false;
        }

        public void OnClick()
        {
            GlobalContainer.LevelManager.LoadNext();
        }
        
    }
}