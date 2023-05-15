using GameCore.Affectables.Breaking;
using GameCore.Stats.Health;
using UnityEngine;

namespace CollectShooter.Weapons
{
    public class WallEntity : MonoBehaviour
    {
        public float health;
        public HealthDisplay display;
        public BreakableBody body;
        
    }
}