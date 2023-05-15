using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CollectShooter.Player.Controls
{
    public class JoystickUI : MonoBehaviour
    {
        public Transform movable;
        public GameObject joystick;
        public List<ImageData> images; 
        public JoystickSettings settings;
        
        private Coroutine _fading;
        
        [System.Serializable]
        public class ImageData
        {
            public float normalAlpha;
            public Image image;

            public void SetInterpolatedFadeOut(float t)
            {
                var color = image.color;
                color.a = Mathf.Lerp(normalAlpha, 0f, t);
                image.color = color;
            }

            public void SetNormalAlpha()
            {
                var color = image.color;
                color.a = normalAlpha;
                image.color = color;
            }
        }
        
        public void Show(Vector3 position)
        {
            joystick.SetActive(true);
            StopFading();
            Reset();
            joystick.transform.position = position;
            foreach (var imData in images)
            {
                imData.SetNormalAlpha();
            }
        }

        public void Hide()
        {
            Reset();
            StopFading();
            _fading = StartCoroutine(Fading());
        }

        public void Reset()
        {
            movable.localPosition = Vector3.zero;
        }

        public void Move(Vector3 dir)
        {
            var nextPos = movable.localPosition + dir.normalized * settings.sensitivity * 1/60f;    
            if (nextPos.magnitude < settings.maxRad)
            {
                movable.localPosition = nextPos;
            }
        }

        private void StopFading()
        {
            if(_fading != null)
                StopCoroutine(_fading);
        }

        private IEnumerator Fading()
        {
            var elapsed = 0f;
            var time = settings.hideTime;
            while (elapsed < time)
            {
                foreach (var imData in images)
                {
                    imData.SetInterpolatedFadeOut(elapsed / time);
                }
                elapsed += Time.deltaTime;
                yield return null;
            }
            joystick.SetActive(false);
        }
    }
}