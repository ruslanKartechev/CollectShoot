using GameCore.Data;
using GameCore.Player;
using UnityEngine;

namespace CollectShooter.NPC
{
    public class RivalNpcBehaviour : CharacterBehaviour
    {
        private RivalNpcEntity _entity;
        public override void Init(CharacterEntity entity)
        {
            _entity = (RivalNpcEntity)entity;
            _entity.backpack.Init(_entity);
            _entity.mover.Init(_entity);
            _entity.backpack.OnCollected -= OnCollected;
            _entity.backpack.OnCollected += OnCollected;
        }

        private void OnDisable()
        {
            _entity.backpack.OnCollected -= OnCollected;
        }

        public override void Activate()
        {
            _entity.backpack.Activate(true);
            GoToNext();
        }

        public override void Stop()
        {
            _entity.mover.StopAll();
        }

        public void GoToNext()
        {
            var pos = GetNextPickPosition();
            if (pos == Vector3.positiveInfinity)
            {
                Debug.Log("[Npc] NO point chosen");
                return;
            }
            _entity.mover.MoveTo(pos);
        }

        private void OnCollected()
        {
            GoToNext();
        }

        private Vector3 GetNextPickPosition()
        {
            var max = 100;
            var i = 0;
            var bullets = LevelContainer.collectablesManager.bullets;
            var randomIndex = 0;
            var count = bullets.Count;
            while (i < max)
            {
                randomIndex = UnityEngine.Random.Range(0, count);
                var pp = bullets[randomIndex].instance.pickableItem;
                if (pp.IsPickable)
                {
                    DrawLine(pp.Position);
                    return pp.Position;
                }
                i++;
            }
            Debug.Log($"moving to zero");
            return Vector3.positiveInfinity;
        }

        private void DrawLine(Vector3 pos)
        {
            var offset = 1f;
            var duration = 5;
            var start = transform.position + Vector3.up * offset;
            var end = pos + Vector3.up * offset;
            Debug.DrawLine(start, end, Color.blue, duration);
        }
    }
}