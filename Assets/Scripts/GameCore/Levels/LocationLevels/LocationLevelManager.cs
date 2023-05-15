using GameCore.Data;
using GameCore.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore.Levels.LocationLevels
{
    public class LocationLevelManager : MonoBehaviour, ILevelManager
    {
        public Location CurrentLoadedLocaiton;
        public Level CurrentLoadedLevel;
        public Scene levelScene;
        
        [SerializeField] private LocationsRepository _locations;
        public Level LoadedLevel => CurrentLoadedLevel;

        public int PassedLevels
        {
            get => GlobalData.LevelsPassed;
            set => GlobalData.LevelsPassed = value;
        }

        public void Init()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        public void LoadLast()
        {
            LoadCurrent();
        }

        public void Reload()
        {
            LoadCurrent();
        }

        public void LoadNext()
        {
            PassedLevels++;
            LevelsRepository.Next();
            LoadCurrent();
        }

        public void LoadCurrent()
        {
            Clear();
            var levelInd = LevelsRepository.CurrentIndex;
            var locationInd = LocationsRepository.CurrentIndex;
            if (_locations.GetCurrentData().levels.OutOfLevels(levelInd))
            {
                _locations.NextLocation();
                LevelsRepository.CurrentIndex = levelInd = 0;
                locationInd = LocationsRepository.CurrentIndex;
            }
            GlobalData.LevelIndex = levelInd;
            Dbg.Green($"[LevelManager] level index: {levelInd}, location index: {locationInd}, TOTAL: {PassedLevels}");
            Load(locationInd, levelInd);
        }
        
        private void Load(int locationInd, int levelInd)
        {
            // Dbg.Log($"[LoadCurrent] Location Ind: {locationInd}, Level Ind: {levelInd}");
            var data = _locations.GetData(locationInd);
            var levelScene = data.levels.GetData(levelInd).sceneName;
            SceneManager.LoadScene(levelScene, LoadSceneMode.Additive);
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log($"[LM] Scene: {scene.name}");
            CurrentLoadedLocaiton = FindObjectOfType<Location>();
            CurrentLoadedLevel = CurrentLoadedLocaiton.Level;
            CurrentLoadedLevel.Init();
        }


        public void Clear()
        {
            var count = SceneManager.sceneCount;
            for (int i = count-1; i >= 1; i--)
            {
                var scene = SceneManager.GetSceneAt(i);
                Debug.Log($"Removing scene: {scene.name}");
                SceneManager.UnloadSceneAsync(scene);
            }
        }

    }
    
}