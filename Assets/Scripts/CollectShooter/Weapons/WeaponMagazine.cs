using System;
using System.Collections.Generic;
using CollectShooter.Collectables;
using GameCore.Player;
using UnityEngine;

namespace CollectShooter.Weapons
{
    public class WeaponMagazine : MonoBehaviour
    {
        public event Action OnFull;
        protected const float ModelScaleFactor = 1f;

        public WeaponEntity entity;
        public Queue<IBackpackItem> currentItems;
        protected float _topPosition;
        
        
        public int Count => currentItems.Count;
        public int Max => entity.backpackSettings.MaxCapacity;
        public bool IsFull() => currentItems.Count >= Max;
        
        public virtual void Init(WeaponEntity entity)
        {
            currentItems = new Queue<IBackpackItem>();
            this.entity = entity;
            _topPosition = 0f;
            entity.display.SetCount(0, Max);
        }

        public virtual void PushItem(IBackpackItem item, Team team)
        {
            if (IsFull())
                return;
            var position = new Vector3(0f, _topPosition, 0f);
            var args = new ItemFlyArgs()
            {
                parent = entity.packParent,
                localPosition = position,
                scaleFactor = ModelScaleFactor,
                localRotation = Quaternion.identity,
                moveTime = entity.settings.itemTakeTime,
                onDone = () => {  }
            };
            item.FlyTo(args);
            
            _topPosition += (item.GetSize() 
                             + entity.backpackSettings.ItemsOffset) 
                            * ModelScaleFactor;
            currentItems.Enqueue(item);
            entity.display.SetCount(currentItems.Count, Max);
            if (IsFull())
            {
                OnFull.Invoke();
            }

        }
        


    }
}