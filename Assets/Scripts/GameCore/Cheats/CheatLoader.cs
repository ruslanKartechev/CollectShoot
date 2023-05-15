using System;
using GameCore.Editors;
using GameCore.Servises.Saving;
using UnityEditor;
using UnityEngine;

namespace GameCore.Cheats
{
    public class CheatLoader : MonoBehaviour
    {
        public GameData cheatData;
        public GameDataSaver saver;
        public bool setLevels;
        public bool setMoney;
        public bool setWeapons;
        public bool setTutors;
        
        public void Init()
        {
            var savedData = saver.LoadedData;
            if(setTutors)
                savedData.DidPlayTutorials = cheatData.DidPlayTutorials;
            if (setLevels)
            {
                savedData.LevelIndex = cheatData.LevelIndex;
                savedData.LocationIndex = cheatData.LocationIndex;
                savedData.LevelsPassed = cheatData.LevelsPassed;
            }

            if (setMoney)
            {
                savedData.MoneyCount = cheatData.MoneyCount;
            }

            if (setWeapons)
            {
                savedData.CurrentStatsIndex = cheatData.CurrentStatsIndex;
            }
            saver.InitLoadedData();
        }

        public void SetLevelIndex(int index)
        {
            cheatData.LevelIndex = cheatData.LevelsPassed = index;
        }

        public void AddMoney()
        {
            
        }

        public void Win()
        {
            
        }

        public void Loose()
        {
            
        }

        public void Restart()
        {
            
        }
        
        
        
        private bool _paused;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_paused)
                {
                    _paused = false;
                    Time.timeScale = 1f;
                }
                else
                {
                    _paused = true;
                    Time.timeScale = 0f;
                }
            }
        }
    }
    
    
    
    #if UNITY_EDITOR
    
    public class CheatLoaderEditor : Editor
    {
        public CheatLoader me;

        private void OnEnable()
        {
            me = target as CheatLoader;
        }

        public override void OnInspectorGUI()
        {
            EditorUtils.LabelCenter("Cheats");
            GUILayout.BeginHorizontal();
            EditorUtils.ButtonNoText($"$$$", Color.green * 0.9f, me.AddMoney, me);
            
            GUILayout.EndHorizontal();
        }
    }
    #endif  
}