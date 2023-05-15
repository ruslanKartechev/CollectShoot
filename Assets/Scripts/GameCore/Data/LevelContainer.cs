using CollectShooter.Collectables;
using CollectShooter.Levels.LevelPart;
using GameCore.Levels;
using GameCore.Player;

namespace GameCore.Data
{
    public static class LevelContainer
    {
        public static Level level;
        public static PlayerEntity player;
        public static LevelPart currentLevelPart;
        public static CollectablesManager collectablesManager;
    }
}