using GameCore.Data;
using UnityEngine;

namespace CollectShooter.Player.Controls
{
    public class ControlsUI : MonoBehaviour
    {
        [SerializeField] private UIInputSettings _settings;
        [SerializeField] private JoystickUI _joystick;
        private bool _moving;
        private void Awake()
        {
            IsEnabled = false;
            _joystick.Hide();
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled == value)
                    return;
                _isEnabled = value;
                if (value)
                {
                    // Activate();
                    // if(Input.GetMouseButton(0))
                        // OnClick(Input.mousePosition);
                }
                else
                {
                    // Deactivate();
                    // OnRelease(Vector3.zero);
                }
            }
        }

        private void Activate()
        {
            GlobalContainer.InputManager.OnClick += OnClick;
            GlobalContainer.InputManager.OnRelease += OnRelease;
            GlobalContainer.InputManager.OnMoved += Move;
        }

        private void Deactivate()
        {
            GlobalContainer.InputManager.OnClick -= OnClick;
            GlobalContainer.InputManager.OnRelease -= OnRelease;
            GlobalContainer.InputManager.OnMoved -= Move;
        }

        public void OnClick(Vector3 pos)
        {
            _moving = true;
            _joystick.Show(pos);       
        }
        
        public void OnRelease(Vector3 obj)
        {
            _moving = false;
            _joystick.Hide();
        }

        public Vector3 CalculateMove(Vector3 moveVector)
        {
            var screenFactor = Screen.width / _settings.referenceResolution;
            var scaled = moveVector * screenFactor;
            var moveMagn = scaled.magnitude;
            var threshold = _settings.moveThreshold * screenFactor;
            // Dbg.Yellow($"*** Factor: {screenFactor}, magn: {moveMagn}, move threshold: {threshold}, width: {Screen.width}");
            if (moveMagn > 0 && moveMagn > threshold)
            {
                return scaled;
            }
            return Vector3.zero;
        }

        public Vector3 MoveUI(Vector3 dir)
        {
            _joystick.Move(dir);
            return _joystick.movable.localPosition;
        }

        public void Move(Vector3 moveVector)
        {
            if (!_moving)
                return;
            var screenFactor = Screen.width / _settings.referenceResolution;
            var scaled = moveVector * screenFactor;
            var moveMagn = scaled.magnitude;
            var threshold = _settings.moveThreshold * screenFactor;
            // Dbg.Yellow($"*** Factor: {screenFactor}, magn: {moveMagn}, move threshold: {threshold}, width: {Screen.width}");
            if (moveMagn > 0 && moveMagn > threshold)
            {
                _joystick.Move(scaled);
            }
            else
            {
                _joystick.Move(Vector3.zero);
            }
        }

    }
}