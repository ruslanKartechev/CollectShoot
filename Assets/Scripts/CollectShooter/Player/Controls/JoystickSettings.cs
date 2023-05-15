using UnityEngine;

namespace CollectShooter.Player.Controls
{
    [CreateAssetMenu(fileName = nameof(JoystickSettings), menuName = "SO/" + nameof(JoystickSettings))]
    public class JoystickSettings : ScriptableObject
    {
        public float maxRad;
        public float sensitivity;
        public float hideTime;
    }
}