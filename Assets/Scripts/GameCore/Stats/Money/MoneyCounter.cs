using GameCore.Data;

namespace GameCore.Stats.Money
{
    public static class MoneyCounter
    {
        public static ReactiveProperty<int> TotalMoney = new ReactiveProperty<int>();
        public static ReactiveProperty<int> LevelMoney = new ReactiveProperty<int>();

        public static void AddLevelAndTotal(int added)
        {
            TotalMoney.Value += added;
            LevelMoney.Value += added;
            // Debug.Log($"added: {added} money");
        }
    }
}