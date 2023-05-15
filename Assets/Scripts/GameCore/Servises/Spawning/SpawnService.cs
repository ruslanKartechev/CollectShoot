using UnityEngine;

namespace GameCore.Servises.Spawning
{
    public class SpawnService : MonoBehaviour, ISpawnService
    {
        [SerializeField] private Transform _defaultParent;
        public Transform DefaultParent => _defaultParent;
        
        public GameObject SpawnGameObject(SpawnArgs args)
        {
            var instance = Instantiate(args.Prefab.gameObject,  args.Position, args.Rotation);
            instance.transform.parent = args.Parent;
            instance.transform.localScale = args.Scale;
            return instance.gameObject;
        }

        public T SpawnFor<T>(SpawnArgs args)
        {
            var instance = Instantiate(args.Prefab.gameObject,  args.Position, args.Rotation);
            instance.transform.parent = args.Parent;
            instance.transform.localScale = args.Scale;
            return instance.GetComponent<T>();   
        }
        
    }
}