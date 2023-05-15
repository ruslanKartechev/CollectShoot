using GameCore.Data;
using GameCore.Player;
using UnityEngine;

namespace CollectShooter.Collectables
{
    public class PlayerBackpack : Backpack
    {
        public override void Init(CharacterEntity entity)
        {
            base.Init(entity);
            _entity.backpackDisplay.InitPosition(_entity.packParent);  
            _entity.backpackDisplay.SetCount(0, _entity.backpackSettings.MaxCapacity);
        }

        public override void PushItem(IBackpackItem item)
        {
            if (IsFull())
            {
                return;
            }
            var position = new Vector3(0f, _topPosition, 0f);
            item.Collect(_entity.packParent, position, ModelScaleFactor,() => { Debug.Log("Fly end");});
            _topPosition += (item.GetSize() 
                             + _entity.backpackSettings.ItemsOffset) 
                            * ModelScaleFactor;
            currentItems.Push(item);
            _entity.backpackDisplay.UpdateCountUp(Count, MaxCount);
            item.SetTeam(_entity.Team);
        }

        public override IBackpackItem PullItem()
        {
            var res = base.PullItem();
            if(res != null)
                _entity.backpackDisplay.UpdateCountDown(Count, MaxCount);
            return res;
        }

        private int MaxCount => _entity.backpackSettings.MaxCapacity;
        
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Collectable))
            {
                var item = other.gameObject.GetComponent<IBackpackItem>();
                if (item != null)
                {
                    PushItem(item);
                }
            }
        }   
    }
}