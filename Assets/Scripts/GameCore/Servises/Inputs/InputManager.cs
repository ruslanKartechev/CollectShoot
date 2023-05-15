using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameCore.Servises.Inputs
{
    public class InputManager : MonoBehaviour, IInputManager
    {
        public int UILayer;
        public event Action<Vector3> OnClick;
        public event Action<Vector3> OnRelease;
        public event Action<Vector3> OnMoved;

        private Coroutine _inputChecking;
        private bool _enabled;
        public bool IsEnabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                if (value)
                {
                    Stop();
                    _inputChecking = StartCoroutine(InputChecking());
                }
                else
                {
                    Stop();
                }
            }
        }

        private void Stop()
        {
            if(_inputChecking != null)
                StopCoroutine(_inputChecking);
        }
        
        private IEnumerator InputChecking()
        {
            var newPos = Input.mousePosition;
            var oldPos = Input.mousePosition;
            while (true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    newPos = oldPos = Input.mousePosition;
                    if (IsPointerOverUIElement() == false)
                    {
                        OnClick?.Invoke(newPos);
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    newPos = oldPos = Input.mousePosition;
                    if(IsPointerOverUIElement() == false)
                        OnRelease?.Invoke(Input.mousePosition);
                }

                if (Input.GetMouseButton(0))
                {
                    newPos = Input.mousePosition;
                    var delta = newPos - oldPos;
                    OnMoved?.Invoke(delta);
                    oldPos = newPos;
                }

                yield return null;
            }
        }
        
        
        // checking over ui
        public bool IsPointerOverUIElement()
        {
            return IsPointerOverUIElement(GetEventSystemRaycastResults());
        }

        //Returns 'true' if we touched or hovering on Unity UI element.
        private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
        {
            for (int index = 0; index < eventSystemRaysastResults.Count; index++)
            {
                var curRaysastResult = eventSystemRaysastResults[index];
                if (curRaysastResult.gameObject.layer == UILayer)
                {
                    // Debug.Log($"UI GO: {curRaysastResult.gameObject.name}");
                    return true;
                }
            }
            return false;
        }
 
 
        //Gets all event system raycast results of current mouse or touch position.
        static List<RaycastResult> GetEventSystemRaycastResults()
        {
            var eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            var raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raysastResults);
            return raysastResults;
        }
    }
}