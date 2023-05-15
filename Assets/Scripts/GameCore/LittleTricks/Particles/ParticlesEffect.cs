using UnityEngine;

namespace GameCore.LittleTricks.Particles
{
    public class ParticlesEffect : MonoBehaviour
    {
        public bool DisableOnStart = true;
        public ParticleSystem particles;
        
        private bool _active = true;
        private void Start()
        {
            if (DisableOnStart)
                Active = false;
        }

        public bool Active
        {
            get => _active;
            set
            {
                // Debug.Log($"active: {value}");
                if (_active == value)
                    return;
                _active = value;
                particles.gameObject.SetActive(value);
                particles.Play();
            }
        }

        public void SetPosition(Vector3 position)
        {
            particles.transform.position = position;
        }
    }
}