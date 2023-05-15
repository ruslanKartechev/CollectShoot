using UnityEngine;

namespace GameCore.LittleTricks.Effects
{
    public class FaceCameraPlaneRotator : MonoBehaviour
    {
        public Vector3 AddedRotation;
        private Transform _camera;
     
        private void Start()
        {
            _camera = Camera.main.transform;
        }
        
        private void Update()
        {
            var atPos = _camera.position;
            atPos.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(atPos - transform.position) *
                                 Quaternion.Euler(AddedRotation);
        }
    }
}