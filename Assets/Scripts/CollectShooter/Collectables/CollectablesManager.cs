using System.Collections.Generic;
using CollectShooter.Teams;
using GameCore.Player;
using UnityEditor;
using UnityEngine;
using Grid = GameCore.Utils.GridUtils.Grid;

namespace CollectShooter.Collectables
{
    public class CollectablesManager : MonoBehaviour
    {
        public BulletSpawnable bulletPrefab;
        public TeamVisualRepository visualRepository;
        public List<BulletSpawnable> bullets;
        [Header("Grid")] 
        public Grid grid;

        public void Generate()
        {
#if UNITY_EDITOR
            Clear();
            bullets = new List<BulletSpawnable>();
            grid.GenerateXZ();
            for (int i = 0; i < grid.GridPositions.GetLength(0); i++)
            {
                for (int k = 0; k < grid.GridPositions.GetLength(1); k++)
                {
                    var pos = grid.GridPositions[i, k];
                    var b = PrefabUtility.InstantiatePrefab(bulletPrefab, transform) as BulletSpawnable;
                    bullets.Add(b);
                    b.transform.position = pos;
                    b.Spawn();
                    b.instance.bullet.SetTeam(GetRandomTeam());
                    b.instance.bullet.UpdateTeamMaterial(visualRepository);
                    EditorUtility.SetDirty(b);
                    EditorUtility.SetDirty(b.instance);
                }                
            }
#endif
        }
        
        public Team GetRandomTeam()
        {
            var i = UnityEngine.Random.Range(0, 4);
            var team = (Team)i;
            return team;
        }

        public void RemoveNulls()
        {
            var start = bullets.Count - 1;
            for (var i = start; i >= 0; i--)
            {
                if (bullets[i] == null)
                {
                    bullets.RemoveAt(i);
                }
            }
        }

        public void RandomizeTeams()
        {
#if UNITY_EDITOR
            foreach (var b in bullets)
            {
                b.instance.bullet.SetTeam(GetRandomTeam());
                b.instance.bullet.UpdateTeamMaterial(visualRepository);
                EditorUtility.SetDirty(b);
                EditorUtility.SetDirty(b.instance);
            }
#endif
        }

        public void Clear()
        {
            if (bullets == null)
                return;
            foreach (var bl in bullets)
            {
                DestroyImmediate(bl.gameObject);
            }   
            bullets.Clear();
        }
    }
}