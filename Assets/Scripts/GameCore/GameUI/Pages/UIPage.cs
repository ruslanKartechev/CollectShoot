using UnityEngine;
using UnityEngine.UI;

namespace GameCore.GameUI.Pages
{
    public class UIPage : MonoBehaviour, IUIPage
    {
        [SerializeField] protected int _order = 1;
        [SerializeField] protected Canvas _canvas;
        [SerializeField] protected GraphicRaycaster _raycaster;
        protected bool _isOpen;
        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                _isOpen = value;
                if (value)
                {
                    _canvas.enabled = true;
                    _raycaster.enabled = true;
                    _canvas.sortingOrder = _order;
                }
                else
                {
                    _canvas.enabled = false;
                    _raycaster.enabled = false;   
                }
            }
        }

        public virtual void Open(bool animated)
        {
            IsOpen = true;
        }

        public virtual void Close(bool animated)
        {
            IsOpen = false;
        }
        
    }
}