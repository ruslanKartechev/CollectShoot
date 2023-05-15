using System.Collections.Generic;
using GameCore.Data;
using UnityEditor;
using UnityEngine;

namespace GameCore.Levels
{
    public class LevelManager : MonoBehaviour, ILevelManager
    {
        [SerializeField] public bool editorMode;
        [SerializeField] public int DebugIndex;
        [SerializeField] public Level CurrentLoadedLevel;
        public List<Level> Levels;
        
        public int LevelsPassed
        {
            get
            {
                if (editorMode)
                    return DebugIndex;
                return GlobalData.LevelsPassed;
            }
            set
            {
                GlobalData.LevelsPassed = value;
                DebugIndex = value;
            }
        }

        public int CurrentIndex
        {
            get
            {
                if (editorMode)
                {
                    return DebugIndex;
                }
                return GlobalData.LevelIndex;
            }
            set
            {
                if (editorMode)
                {
                    DebugIndex = value;
                }
                else
                {
                    GlobalData.LevelIndex = value;
                }
            }
        }

        public Level LoadedLevel => CurrentLoadedLevel;

        public void Init()
        {
#if !UNITY_EDITOR
        editorMode = false;
#endif
            if (editorMode)
            {
                GlobalData.LevelsPassed = DebugIndex;
            }
            else
            {
                CurrentIndex = GlobalData.LevelIndex;
                LevelsPassed = GlobalData.LevelsPassed;               
            }
        }


        public void LoadLast()
        {
            LoadLevel(CurrentIndex);
        }

        public void Reload()
        {
            LoadLevel(CurrentIndex);
        }

        public void LoadNext()
        {
            LevelsPassed++;
            CurrentLoadedLevel?.Unload();
            LoadLevel(CurrentIndex + 1);
        }


        public void LoadLevel(int levelIndex)
        {
            levelIndex = GetCorrectedIndex(levelIndex);
            CurrentIndex = levelIndex;
            var level = Levels[levelIndex];
            Clear();
            SpawnLevel(level);
            DebugIndex = levelIndex;
        }


        private int GetCorrectedIndex(int levelIndex)
        {
            if (editorMode)
                return levelIndex > Levels.Count - 1 || levelIndex <= 0 ? 0 : levelIndex;
            var totalCount = LevelsPassed;
            if (totalCount > Levels.Count - 1)
            {
                if (Levels.Count == 1)
                    return 0;
                // Dbg.Yellow("RANDOMIZING LEVELS");
                var level = CurrentIndex;
                var startIndex = level;
                while (level == startIndex)
                {
                    level = UnityEngine.Random.Range(0, Levels.Count);
                }
                return level;
            }
            return levelIndex;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void SpawnLevel(Level levelData)
        {
            if (!levelData) 
                return;
            if (Application.isPlaying)
            {
                var instance = Instantiate(levelData, transform);
                CurrentLoadedLevel = instance.GetComponent<Level>();
                CurrentLoadedLevel.Init();
                instance.transform.position = transform.position;
            }
            else
            {
#if UNITY_EDITOR
                var instance = PrefabUtility.InstantiatePrefab(levelData, transform) as Level;
                if (instance != null)
                {
                    instance.transform.position = transform.position;
                    CurrentLoadedLevel = instance.GetComponent<Level>();
                }
#endif
            }

        }
        
        public void EditorNext()
        {
            DebugIndex++;
            DebugIndex = Mathf.Clamp(DebugIndex, 0, Levels.Count - 1);
            LoadLevel(DebugIndex);
        }

        public void EditorPrev()
        {
            DebugIndex--;
            DebugIndex = Mathf.Clamp(DebugIndex, 0, Levels.Count - 1);
            LoadLevel(DebugIndex);
        }

        private void Clear()
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i).gameObject;
                if (Application.isPlaying)
                    Destroy(child);
                else
                    DestroyImmediate(child);
            }
        }

    }
}