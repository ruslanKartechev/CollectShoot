using System.Collections.Generic;
using GameCore.Data;
using GameCore.LittleTricks;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.GameUI.Pages.Impl
{
    public class FailUIPage : UIPageWithButton, IFailPage
    {
        [SerializeField] private List<PulsingAnimator> _animators;
        
            
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
        
        public override void Open(bool animated)
        {
            base.Open(animated);
            // _button.onClick.AddListener(OnClick);
        }

        public override void Close(bool animated)
        {
            base.Close(animated);
            // _button.onClick.RemoveListener(OnClick);
        }

        public void OnClick()
        {
            GlobalContainer.LevelManager.Reload();
        }

    }
}