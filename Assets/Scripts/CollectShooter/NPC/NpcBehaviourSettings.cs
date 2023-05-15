using UnityEngine;

namespace CollectShooter.NPC
{
    [CreateAssetMenu(menuName = "SO/" + nameof(NpcBehaviourSettings), fileName = nameof(NpcBehaviourSettings), order = 0)]
    public class NpcBehaviourSettings : ScriptableObject
    {
        public float backpackFillToDeliver = 1;
    }
}