using GameCore.Cheats;
using GameCore.Data;
using GameCore.Servises.Saving;
using UnityEngine;

namespace GameCore
{
    public class GameBoot : MonoBehaviour
    {
        public BootSettings settings;
        public CheatLoader cheats;
        public DataSaver saver;
        public GlobalContainerLocator locator;

        private void Awake()
        {
            locator.Init();
            saver.LoadData();
            GlobalData.ShowWeaponOffers = settings.ShowWeaponOffers;
            if(settings.UseCheats)
                cheats.Init();
            else
                saver.InitLoadedData();
        }

        void Start()
        {
            UIContainer.UIManager.Init();
            GlobalContainer.LevelManager.Init();
            GlobalContainer.LevelManager.LoadLast();
        }

        private void OnDisable()
        {
            if(settings.SaveOnExit)
                saver.SaveData();
        }
    }
    
}
