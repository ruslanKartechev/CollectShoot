// using MoreMountains.NiceVibrations;

namespace GameCore.LittleTricks.Haptique
{
    public class HaptiqueManager
    {
        private static bool _active;
        
        public static void PlayHaptique()
        {
            if (_active == false)
            {
                _active = true;
                // MMVibrationManager.SetHapticsActive(true);
            }
            // MMVibrationManager.Haptic(HapticTypes.LightImpact);
            // Debug.Log("Started haptique");
        }
    }
}