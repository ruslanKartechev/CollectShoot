using System.Collections.Generic;
using System.Linq;
using GameCore.Usables.Bullets;
using UnityEngine;

namespace Pool.Impls
{
    public class BulletsPool : MonoBehaviour, IPool<PooledBulletBase>
    {
        [SerializeField] private int _spawnCount = 30;
        [SerializeField] private PooledBulletBase _prefab;
        
        private Dictionary<PooledBulletBase, bool> _pool = new Dictionary<PooledBulletBase, bool>();
        private bool _inited;

        public void Init()
        {
            if (_inited)
                return;
            _inited = true;
            Spawn(_spawnCount);
        }
        
        private void Spawn(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var instance = Instantiate(_prefab, transform.position, transform.rotation, transform);
                var item = instance.GetComponent<PooledBulletBase>();
                item.Init(this);
                _pool.Add(item, true);
                instance.gameObject.SetActive(false);
            }
            
            for (var i = 0; i < count; i++)
            {
                var instance = Instantiate(_prefab, transform.position, transform.rotation, transform);
                var item = instance.GetComponent<PooledBulletBase>();
                item.Init(this);
                _pool.Add(item, true);
                instance.gameObject.SetActive(false);
            }
        }
        public PooledBulletBase GetItem()
        {
            var pair = _pool.FirstOrDefault(t => t.Value);
            if (pair.Equals(default(KeyValuePair<PooledBulletBase, bool>)))
            {
                Spawn(_spawnCount);
                pair = _pool.FirstOrDefault(t => t.Value);
            }
            var item = pair.Key;
            _pool[item] = false;
            return item;
        }

        public void Return(PooledBulletBase target)
        {
            _pool[target] = true;
        }

        public void CollectAllBack()
        {
            foreach (var pair in _pool)
            {
                pair.Key.CollectBack();
                _pool[pair.Key] = true;
            }
        }
    }
}