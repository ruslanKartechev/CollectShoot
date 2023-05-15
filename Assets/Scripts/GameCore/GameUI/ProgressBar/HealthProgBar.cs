
namespace GameCore.GameUI.ProgressBar
{
    public class HealthProgBar : SimpleProgressBar
    {
        protected float _max = 100;
       
        public void Init(float maxHealth, float currentHeath)
        {
            _val = currentHeath / maxHealth;
            SetValue(_val);
            _max = maxHealth;
        }
        
        public void UpdateHealth(float health)
        {
            var val = health / _max;
            ChangeValue(val);
        }
        
    }
}