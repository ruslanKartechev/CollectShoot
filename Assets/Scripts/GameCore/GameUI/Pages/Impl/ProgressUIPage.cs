using UnityEngine;
using UnityEngine.UI;

namespace GameCore.GameUI.Pages.Impl
{
    public class ProgressUIPage : UIPage, IProgressPage
    {
        
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
            IsOpen = true;
        }

        private void OnClicked()
        {
            Debug.Log("[UI] fire button");
            // LevelContainer.player.weaponFiring.Fire();
        }


        public override void Close(bool animated)
        {
            IsOpen = false;
        }
        
    }
}