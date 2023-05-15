namespace GameCore.GameUI.Pages
{
    public interface IUIPage
    {
        void Open(bool animated = false);
        void Close(bool animated = false);
    }
}