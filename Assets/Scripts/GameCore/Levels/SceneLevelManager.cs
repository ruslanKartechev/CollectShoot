using System.Collections.Generic;
using GameCore.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore.Levels
{
    public partial class SceneLevelManager : MonoBehaviour, ILevelManager
    {
        public EditorSwitcher editorSwitcher;
        public Level CurrentLoadedLevel;
        public Scene LoadedScene;
        public List<string> Levels;
        
        public int LevelsPassed
        {
            get => GlobalData.LevelsPassed;
            set => GlobalData.LevelsPassed = value;
        }

        public int CurrentIndex
        {
            get => GlobalData.LevelIndex;
            set => GlobalData.LevelIndex = value;
        }

        public Level LoadedLevel => CurrentLoadedLevel;
        
        public void Init()
        {
            CurrentIndex = GlobalData.LevelIndex;
            LevelsPassed = GlobalData.LevelsPassed;
            SceneManager.sceneLoaded += OnSceneLoaded;
#if UNITY_EDITOR
            editorSwitcher.ClearAll();
#endif
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
            var levelName = Levels[levelIndex];
            LoadScene(levelName);
        }
        

        private void LoadScene(string sceneName)
        {
            // Debug.Log($"[LM] Loading: {sceneName} ...");
            UnloadPrev();
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            LoadedScene = scene;
            CurrentLoadedLevel = FindObjectOfType<Level>();
            CurrentLoadedLevel.Init();
        }

        private void UnloadPrev()
        {
            if(CurrentLoadedLevel != null)
                CurrentLoadedLevel.Unload();
            if(LoadedScene.name != null)
                SceneManager.UnloadSceneAsync(LoadedScene);
            CurrentLoadedLevel = null;
        }
        
        
        private int GetCorrectedIndex(int levelIndex)
        {
            var totalCount = LevelsPassed;
            if (totalCount > Levels.Count - 1)
            {
                if (Levels.Count == 1)
                    return 0;
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
    }
}