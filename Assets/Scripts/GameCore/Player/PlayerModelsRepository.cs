using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCore.Player
{
    [CreateAssetMenu(fileName = nameof(PlayerModelsRepository), menuName = "SO/"+nameof(PlayerModelsRepository))]
    public class PlayerModelsRepository : ScriptableObject
    {
        public List<Data> models;

        public PlayerModel GetModelAt(int level)
        {
            return models[level].prefab;
        }
        
        public PlayerModel GetModelAt(PlayerModelName mName)
        {
            return models.FirstOrDefault(t => t.name == mName).prefab;
        }

        public PlayerModel GetFirst()
        {
            return models[0].prefab;
        }
        
        
        
        
        [System.Serializable]
        public class Data
        {
            public PlayerModelName name;
            public PlayerModel prefab;
        }
    }
}