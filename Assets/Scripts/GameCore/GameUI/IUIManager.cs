namespace GameCore.GameUI
{
    public interface IUIManager
    {
        void Init();
        void CloseAll();
        void ShowStart();
        void ShowWin();
        void ShowFail();
        void ShowProgress();
    }
}