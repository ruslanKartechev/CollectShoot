namespace GameCore.Usables.Bullets
{
    public interface IBullet
    {
        void ShootAt(BulletShootArgs args);
        public float Velocity { get; set; }
        public float Damage { get; set; }
    }
}