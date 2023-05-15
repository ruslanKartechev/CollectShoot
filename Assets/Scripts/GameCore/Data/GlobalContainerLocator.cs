using CollectShooter.Teams;
using GameCore.GameCamera;
using GameCore.Levels;
using GameCore.Player;
using GameCore.Servises.Inputs;
using GameCore.Servises.Saving;
using GameCore.Servises.Spawning;
using GameCore.Utils.MonoUtils.Impl;
using UnityEngine;

namespace GameCore.Data
{
    public class GlobalContainerLocator : MonoBehaviour
    {
        public UIContainerLocator uiLocator;
        [Header("Camera")]
        public CameraLocalShaker cameraShaker;
        public CameraPointMover cameraPointMover;
        [Header("Other")]
        public MainConfig mainConfig;
        public DataSaver dataSaver;
        public PlayerModelsRepository playerModelsRepository;
        [Space(10)]
        public SceneLevelManager levelManager;
        public InputManager input;
        public SpawnService spawnService;
        public CoroutineService coroutineService;
        public TeamVisualRepository TeamVisualRepository;

        
        public void Init()
        {
            Debug.Log($"[ContainerLocator] Init");
            var cam = Camera.main;
            GlobalContainer.ActiveCamera = cam;
            GlobalContainer.CameraTransform = cam.transform;
            GlobalContainer.LevelManager = levelManager;
            GlobalContainer.CameraShaker = cameraShaker;
            GlobalContainer.MainConfig = mainConfig;
            GlobalContainer.CameraPointMover = cameraPointMover;
            GlobalContainer.InputManager = input;
            GlobalContainer.SpawnService = spawnService;
            GlobalContainer.ParentService = new ParentService();
            GlobalContainer.CoroutineService = coroutineService;
            GlobalContainer.PlayerModelsRepository = playerModelsRepository;
            GlobalContainer.DataSaver = dataSaver;
            GlobalContainer.TeamVisualRepository = TeamVisualRepository;
            uiLocator.Init();
        }
        
    }
}