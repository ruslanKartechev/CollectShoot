namespace GameCore.Levels
{
    public interface ILevelManager
    {
        Level LoadedLevel { get; }
        void LoadLast();
        void LoadNext();
        void Reload();
        void Init();
    }
}