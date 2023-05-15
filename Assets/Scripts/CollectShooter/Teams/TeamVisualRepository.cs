using System;
using System.Collections.Generic;
using GameCore.Player;
using UnityEngine;

namespace CollectShooter.Teams
{
    
    [CreateAssetMenu(menuName = "SO/" + nameof(TeamVisualRepository), fileName = nameof(TeamVisualRepository), order = 0)]
    public class TeamVisualRepository : ScriptableObject
    {
        public List<Data> materialData;
        private Dictionary<Team, Data> _table;

        private void OnEnable()
        {
            _table = new Dictionary<Team, Data>();
            foreach (var data in materialData)
            {
                _table.Add(data.Team, data);
            }
        }

        public Material GetMaterial(Team team)
        {
            return _table[team].Material;
        }


        [System.Serializable]
        public class Data
        {
            public Team Team;
            public Material Material;
        }
    }


}