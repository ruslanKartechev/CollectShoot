namespace GameCore.Servises.Saving
{
    [System.Serializable]
    public class GameData
    {
        public bool DidPlayTutorials;
        public int LevelsPassed = 0;
        public int LevelIndex = 0;
        public int LocationIndex = 0;
        public int MoneyCount = 0;

        public int CurrentStatsIndex;

        public GameData()
        {
            LevelIndex = LocationIndex = 0;
        }
    }

    [System.Serializable]
    public class WeaponStatsSD
    {
        public string name;
        public bool isOpen;
        public bool isOffered;
        public int damageUpgradeLevel;
        public int shotsUpgradeLevel;
        public int incomeUpgradeLevel;
        
    }
}