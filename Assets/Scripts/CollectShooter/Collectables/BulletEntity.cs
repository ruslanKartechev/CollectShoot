using CollectShooter.Teams;
using GameCore.Player;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace CollectShooter.Collectables
{
    public class BulletEntity : MonoBehaviour
    {
        public Transform movable;
        public ParticleSystem particles;
        public CollectableSettings settings;
        public Collider collider;
        public Team team;
        public Renderer renderer;
        public PickableItem pickableItem;
        public Bullet bullet;
    }
}