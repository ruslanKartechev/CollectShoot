using GameCore.Data;
using GameCore.LittleTricks;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.GameUI.Pages.Impl
{
    public class StartUIPage : UIPageWithButton, IStartPage
    {
        [SerializeField] private TweenScaler _buttonScaler;
        private bool _clicked;
        private float _buttonScaleUp = 1.1f;
        
        
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
            _clicked = false;
            _button.interactable = true;
            _button.OnDown += OnClick;
            // _buttonScaler.LoopScaling(1f, _buttonScaleUp);
        }

        public override void Close(bool animated)
        {
            base.Close(animated);
            _button.OnDown -= OnClick;
            _button.interactable = false;
            // _buttonScaler.StopAll();
        }

        public void OnClick()
        {
            if (_clicked)
                return;
            _clicked = true;
            LevelContainer.level.StartLevel();
        }
    }
}