﻿using UnityEngine;

namespace GameCore.LittleTricks.Effects
{
    public class FaceCameraRotator : MonoBehaviour
    {
        public Vector3 AddedRotation;
        private Transform _camera;
     
        private void Start()
        {
            _camera = Camera.main.transform;
        }
        
        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _camera.position) *
                                 Quaternion.Euler(AddedRotation);
        }
    }
}