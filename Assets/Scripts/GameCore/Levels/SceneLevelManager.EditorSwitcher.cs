using System.Collections.Generic;
using GameCore.Cheats;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

namespace GameCore.Levels
{
    public partial class SceneLevelManager
    {
        [System.Serializable]
        public class EditorSwitcher
        {
            public int currentIndex;
            public CheatLoader loader;
            public Scene currentScene;
            
            public void Next(List<string> levels)
            {
                currentIndex = Correct(currentIndex + 1, levels.Count - 1);
                Unload();
                Load(levels[currentIndex]);
            }

            public void Prev(List<string> levels)
            {
                currentIndex = Correct(currentIndex - 1, levels.Count - 1);
                Unload();
                Load(levels[currentIndex]);
            }
            
            
            private int Correct(int index, int max)
            {
                return Mathf.Clamp(index,0, max);
            }

            public void Unload()
            {
#if UNITY_EDITOR
                var count = EditorSceneManager.sceneCount;
                for (int i = count-1; i >= 1; i--)
                {
                    var scene = EditorSceneManager.GetSceneAt(i);
                    EditorSceneManager.CloseScene(scene, true);
                }
                if(currentScene.name != null) 
                    EditorSceneManager.CloseScene(currentScene, true);
#endif
            }

            public void Reset()
            {
                loader.SetLevelIndex(0);
            }
            
            public void ClearAll()
            {
#if UNITY_EDITOR
                var count = SceneManager.sceneCount;
                // Dbg.Red($"Loaded count: {count}");
                for (int i = count-1; i >= 1; i--)
                {
                    var scene = SceneManager.GetSceneAt(i);
                    // Dbg.Yellow($"Closed: {scene.name} scene");
                    SceneManager.UnloadSceneAsync(scene);
                }
#endif
            }


            private string GetPath(string name)
            {
                return "Assets/Scenes/" + name + ".unity";
            }

            private void Load(string name)
            {
#if UNITY_EDITOR
                currentScene = EditorSceneManager.OpenScene(GetPath(name), OpenSceneMode.Additive);
                loader.SetLevelIndex(currentIndex);
                #endif
            }
            
        }
    }
}