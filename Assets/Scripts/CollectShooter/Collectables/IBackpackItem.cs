using System;
using GameCore.Player;
using UnityEngine;

namespace CollectShooter.Collectables
{
    public interface IBackpackItem
    {
        void SetTeam(Team team);
        void Collect(Transform parent, Vector3 localPosition, float scaleFactor, Action onEnd);
        void FlyTo(ItemFlyArgs args);
        float GetSize();
        void Hide();
    }

    public class ItemFlyArgs
    {
        public Transform parent;
        public Vector3 localPosition;
        public Quaternion localRotation;
        public float scaleFactor;
        public float moveTime;
        public Action onDone;
    }
}