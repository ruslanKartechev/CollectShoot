using UnityEngine;

namespace GameCore.Servises.Saving
{
    public class SavedDataInitializer : MonoBehaviour
    {
        public GameDataSaver saver;
        
        public void Init()
        {
            saver.LoadData();   
        }

        private void OnDestroy()
        {
            saver.SaveData();
        }
    }
}