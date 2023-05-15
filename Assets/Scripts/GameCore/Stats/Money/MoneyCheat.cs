using UnityEngine;

namespace GameCore.Stats.Money
{
    public class MoneyCheat : MonoBehaviour
    {
        public int amount;
        public void Add()
        {
            MoneyCounter.AddLevelAndTotal(amount);
        }

        public void SetZero()
        {
            MoneyCounter.TotalMoney.Value = 0;
            MoneyCounter.LevelMoney.Value = 0;
        }
    }
}