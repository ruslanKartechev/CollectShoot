using CollectShooter.Collectables;
using GameCore.LittleTricks.Rotators;
using UnityEngine;

namespace CollectShooter.Weapons
{
    public class WeaponEntity : MonoBehaviour
    {
        public Wall wall;
        public WeaponSettings settings;
        public WeaponMagazine magazine;
        public BackpackSettings backpackSettings;
        public Transform packParent;  
        public BackpackDisplay display;
        public SimpleRotator rotator;
        [Space(10)] 
        public Collider triggerCollider;
        public ParticleSystem particles;
        
    }
}