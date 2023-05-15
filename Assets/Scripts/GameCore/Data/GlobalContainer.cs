using CollectShooter.Collectables;
using CollectShooter.Teams;
using GameCore.GameCamera;
using GameCore.Levels;
using GameCore.Player;
using GameCore.Servises.Inputs;
using GameCore.Servises.Saving;
using GameCore.Servises.Spawning;
using GameCore.Utils.MonoUtils;
using UnityEngine;

namespace GameCore.Data
{
    public static class GlobalContainer
    {
        public static MainConfig MainConfig;
        public static DataSaver DataSaver;
        public static Camera ActiveCamera;
        public static Transform CameraTransform;
        public static ICameraPointMover CameraPointMover;
        public static ICameraShaker CameraShaker;
        
        public static ILevelManager LevelManager;
        public static ICoroutineService CoroutineService;
        public static ISpawnService SpawnService;
        public static IParentService ParentService;
        public static IInputManager InputManager;
        public static PlayerModelsRepository PlayerModelsRepository;
        public static CollectablesManager CollectablesManager;
        public static TeamVisualRepository TeamVisualRepository;

    }
}