namespace GameCore.Data
{
    public static class GlobalData
    {
        public static bool DidPlayTutorials;
        public static int LevelIndex;
        public static int LevelsPassed;
        public static bool UIInputActive = true;
        public static bool ShowWeaponOffers;
        public static ReactiveProperty<int> TotalRatsCount = new ReactiveProperty<int>();
        public static ReactiveProperty<int> AliveRatsCount = new ReactiveProperty<int>();
        public static ReactiveProperty<int> ShotsCount = new ReactiveProperty<int>();
    }
}