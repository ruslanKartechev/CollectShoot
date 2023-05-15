using System;
using System.Collections.Generic;
using GameCore.Player;
using UnityEngine;

namespace CollectShooter.Collectables
{
    public class Backpack : MonoBehaviour
    {
        protected const float ModelScaleFactor = 1f/100;

        public event Action OnCollected;
        public Collider triggerCollider;
        public Stack<IBackpackItem> currentItems;
        
        protected CharacterEntity _entity;
        protected float _topPosition;

        public bool IsFull() => currentItems.Count >= _entity.backpackSettings.MaxCapacity;
        public int Count => currentItems.Count;
        
        public virtual void Init(CharacterEntity entity)
        {
            currentItems = new Stack<IBackpackItem>();
            _entity = entity;
            _topPosition = 0f;
        }

        public virtual void PushItem(IBackpackItem item)
        {
            if (IsFull())
                return;
            var position = new Vector3(0f, _topPosition, 0f);
            item.Collect(_entity.packParent, position, ModelScaleFactor,() => { Debug.Log("Fly end");});
            _topPosition += (item.GetSize() 
                             + _entity.backpackSettings.ItemsOffset) 
                            * ModelScaleFactor;
            currentItems.Push(item);
            item.SetTeam(_entity.Team);
        }

        public virtual IBackpackItem PullItem()
        {
            if (currentItems.Count == 0)
                return null;
            
            var item = currentItems.Pop();
            _topPosition -= (item.GetSize() 
                             + _entity.backpackSettings.ItemsOffset) 
                            * ModelScaleFactor;
            return item;
        }

        public virtual void Activate(bool active)
        {
            triggerCollider.enabled = active;
        }

        protected void RaiseOnCollected()
        {
            OnCollected?.Invoke();
        }
    }
}