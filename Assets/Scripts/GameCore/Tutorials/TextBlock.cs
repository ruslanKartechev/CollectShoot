using GameCore.LittleTricks;
using TMPro;

namespace GameCore.Tutorials
{
    [System.Serializable]
    public class TextBlock
    {
        public TextMeshProUGUI text;
        public TweenScaler scaler;

        public void Show()
        {
            text.enabled = true;
            scaler.LoopScaling(scaler.normalScale, scaler.maxScale);
        }

        public void Hide()
        {
            text.enabled = false;
            scaler.StopAll();
        }
    }
}