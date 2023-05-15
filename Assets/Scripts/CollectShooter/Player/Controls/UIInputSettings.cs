using UnityEngine;

namespace CollectShooter.Player.Controls
{
    [CreateAssetMenu(menuName = "SO/"+nameof(UIInputSettings), fileName = nameof(UIInputSettings), order = 0)]
    public class UIInputSettings : ScriptableObject
    {
        public float referenceResolution;
        public float moveThreshold;
    }
}