using System.Collections.Generic;
using GameCore.Data;
using UnityEngine;

namespace CollectShooter.Levels.LevelPart
{
    public class LevelPartsManager : MonoBehaviour
    {
        public List<LevelPart> parts;
        private int _currentIndex;
        
        public void Init()
        {
            _currentIndex = 0;
            parts[_currentIndex].Init();
        }

        public void ActivateFirst()
        {
            _currentIndex = 0;
            ActivateCurrent();
        }

        public void Next()
        {
            _currentIndex++;
            ActivateCurrent();
        }

        public void ActivateCurrent()
        {
            if (_currentIndex >= parts.Count)
                return;
            LevelContainer.currentLevelPart = parts[_currentIndex];
            parts[_currentIndex].Activate();
        }
        
    }
}