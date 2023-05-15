using UnityEngine;

namespace GameCore.Servises.Saving
{
    public abstract class DataSaver : ScriptableObject
    {
        public abstract void SaveData();
        public abstract void LoadData();
        public abstract void InitLoadedData();
        public abstract GameData LoadedData { get; }
    }
}