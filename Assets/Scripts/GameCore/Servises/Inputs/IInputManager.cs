using System;
using UnityEngine;

namespace GameCore.Servises.Inputs
{
    public interface IInputManager
    {
        public bool IsEnabled { get; set; }
        public event Action<Vector3> OnClick;
        public event Action<Vector3> OnRelease;
        public event Action<Vector3> OnMoved;
        
    }
}