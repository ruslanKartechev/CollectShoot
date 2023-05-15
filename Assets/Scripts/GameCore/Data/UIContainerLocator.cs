using CollectShooter.Player.Controls;
using GameCore.GameUI;
using GameCore.GameUI.Pages;
using GameCore.GameUI.Pages.Impl;
using UnityEngine;

namespace GameCore.Data
{
    public class UIContainerLocator : MonoBehaviour
    {
        [Header("UI")]
        public UIManager uiManager;
        public StartUIPage StartPage;
        public ProgressUIPage ProgPage;
        public WinPage WinPage;
        public FailUIPage FailPage;
        public ControlsUI ControlsUI;
        
        
        public void Init()
        {
            UIContainer.UIManager = uiManager;
            UIContainer.StartPage = StartPage;
            UIContainer.ProgressPage = ProgPage;
            UIContainer.WinPage = WinPage;
            UIContainer.FaiPage = FailPage;
            UIContainer.ControlsUI = ControlsUI;
        }
    }
}