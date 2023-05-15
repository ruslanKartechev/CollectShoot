using System.IO;
using GameCore.Data;
using GameCore.Levels.LocationLevels;
using GameCore.Stats.Money;
using GameCore.Utils;
using UnityEngine;

namespace GameCore.Servises.Saving
{
    [CreateAssetMenu(fileName = nameof(GameDataSaver), menuName = "SO/" + nameof(GameDataSaver))]
    public class GameDataSaver : DataSaver
    {
        private const string FileName = "SavedGameData";
        private GameData _loadedData;

        public override GameData LoadedData => _loadedData;
        private string Path => Application.persistentDataPath + "/" + FileName;

        public void ClearData()
        {
            if (File.Exists(Path))
            {
                File.WriteAllText(Path, "");
            }   
        }
        
        public override void SaveData()
        {
            var data = new GameData();
            SaveLevel(data);
            SaveMoney(data);
            // SaveWeaponStats(data);
            data.DidPlayTutorials = GlobalData.DidPlayTutorials;
            
            var jsonString = JsonUtility.ToJson(data);
            File.WriteAllText(Path, jsonString);
        }

        public override void LoadData()
        {
            Debug.Log("[DataSaver] Loading game data");
            if (File.Exists(Path))
            {
                var fileContents = File.ReadAllText(Path);
                _loadedData = JsonUtility.FromJson<GameData>(fileContents);
                if (_loadedData == null)
                    _loadedData = new GameData();
            }
            else
            {
                _loadedData = new GameData();
            }
        }
        
        public override void InitLoadedData()
        {
            InitLevel();
            InitMoney();
            // InitWeaponStats();
            GlobalData.DidPlayTutorials = _loadedData.DidPlayTutorials;
        }


        private void SaveLevel(GameData data)
        {
            data.LevelIndex = LevelsRepository.CurrentIndex;
            data.LocationIndex = LocationsRepository.CurrentIndex;
            data.LevelsPassed = GlobalData.LevelsPassed;
        }

        private void SaveMoney(GameData data)
        {
            data.MoneyCount = MoneyCounter.TotalMoney.Value;
        }

        
        private void InitLevel()
        {
            LevelsRepository.CurrentIndex = _loadedData.LevelIndex;
            LocationsRepository.CurrentIndex = _loadedData.LocationIndex;
            GlobalData.LevelsPassed = _loadedData.LevelsPassed;
        }

        private void InitMoney()
        {
            MoneyCounter.TotalMoney.Value = _loadedData.MoneyCount;
        }
        
        
        
        
        
        
        #if UNITY_EDITOR
        public void DebugPath()
        {
            Dbg.Green("Saved FILE:   " + Path);
            Dbg.Green("PDT:  " + Application.persistentDataPath);
        }
        #endif
    }
}