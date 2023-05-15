using System.Collections.Generic;
using UnityEngine;

namespace GameCore.Levels.LocationLevels
{
    
    [CreateAssetMenu(fileName = nameof(LocationsRepository), menuName = "SO/" + nameof(LocationsRepository))]
    public class LocationsRepository : ScriptableObject
    {
        public static int CurrentIndex;

        public List<LocData> locations = new List<LocData>();
        private LocData _currentData;
        
        public int TotalCount => locations.Count;
        
        
        public LocData GetData(int index) => locations[index];
        
        public LocData GetCurrentData()
        {
            return locations[CurrentIndex];
        }
        
        public LocData GetNextData()
        {
            return locations[GetNextIndex()];
        }

        public int GetNextIndex()
        {
            var next = CurrentIndex + 1;
            return CorrectIndex(next);
        }
        
        public int NextLocation()
        {
            CurrentIndex = CorrectIndex(CurrentIndex + 1);
            return CurrentIndex;
        }

        public int CorrectIndex(int index)
        {
            if (index >= locations.Count || index < 0)
                return 0;
            return index;
        }
        
        
        [System.Serializable]
        public class LocData
        {
            public LevelsRepository levels;
        }
    }
}