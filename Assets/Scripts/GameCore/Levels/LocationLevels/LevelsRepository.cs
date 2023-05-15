using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Levels.LocationLevels
{
    [CreateAssetMenu(fileName = nameof(LevelsRepository), menuName = "SO/" + nameof(LevelsRepository))]

    public class LevelsRepository : ScriptableObject
    {
        public static int CurrentIndex;
        
        public static int Next() => CurrentIndex++;

        public List<LevelData> levels = new List<LevelData>();

        public int TotalCount => levels.Count;
        

        public LevelData GetData(int index) => levels[index];


        public bool OutOfLevels(int index)
        {
            return index >= levels.Count;
        }
        
        
        public int CorrectIndex(int index)
        {
            if (index >= levels.Count || index < 0)
                return 0;
            return index;
        }

        
        [System.Serializable]
        public class LevelData
        {
            public string sceneName;
            public Level level;
            public Vector3 spawnPosition;
            public Vector3 spawnedEulers;
        }
    }
}