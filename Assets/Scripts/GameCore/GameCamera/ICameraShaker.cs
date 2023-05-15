namespace GameCore.GameCamera
{
    public interface ICameraShaker
    {
        public void Shake(float duration, float magnitude);
        public void StopShaking();
        public void DefaultShake();

    }
}