using CollectShooter.Player.Controls;
using GameCore.GameUI;
using GameCore.GameUI.Pages;

namespace GameCore.Data
{
    public static class UIContainer
    {
        public static IUIManager UIManager;
        public static IStartPage StartPage;
        public static IProgressPage ProgressPage;
        public static IWinPage WinPage;
        public static IFailPage FaiPage;
        public static ControlsUI ControlsUI;

    }
}