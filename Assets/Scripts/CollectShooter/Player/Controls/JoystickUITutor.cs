using DG.Tweening;
using UnityEngine;

namespace CollectShooter.Player.Controls
{
    public class JoystickUITutor : MonoBehaviour
    {
        public JoystickUI ui;
        private Sequence _sequence;
        private float _moveTime = 1f;
        public void Show(Vector3 position)
        {
            ui.Show(position);
            var tt = ui.movable;
            var rightPos = Vector3.right * ui.settings.maxRad;
            var leftPos = -Vector3.right * ui.settings.maxRad;
            tt.localPosition = rightPos;
            _sequence = DOTween.Sequence();
            _sequence.Append(tt.DOLocalMove(leftPos, _moveTime))
                .Append(tt.DOLocalMove(rightPos, _moveTime)).SetLoops(-1);
        }

        public void Stop()
        {
            _sequence?.Kill();
        }
        
    }
}