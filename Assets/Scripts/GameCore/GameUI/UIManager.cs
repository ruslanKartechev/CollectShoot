using GameCore.Data;
using UnityEngine;

namespace GameCore.GameUI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        public void Init()
        {
            CloseAll();
        }

        public void CloseAll()
        {
            UIContainer.FaiPage.Close(false);
            UIContainer.WinPage.Close(false);
            UIContainer.StartPage.Close(false);
            UIContainer.ProgressPage.Close(false);
        }

        public void ShowStart()
        {
            CloseAll();
            UIContainer.StartPage.Open(false);
        }
        

        public void ShowWin()
        {
            CloseAll();
            UIContainer.WinPage.Open(true);
        }

        public void ShowFail()
        {
            CloseAll();
            UIContainer.FaiPage.Open(true);
        }

        public void ShowProgress()
        {
            CloseAll();
            UIContainer.ProgressPage.Open(true);
        }
    }
}