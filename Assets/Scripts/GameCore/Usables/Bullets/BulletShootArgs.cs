using System;
using UnityEngine;

namespace GameCore.Usables.Bullets
{
    public struct BulletShootArgs
    {
        public Vector3 from;
        public Vector3 to;
        public Quaternion Rotation;
        public int bulletLayer;
        public bool willDamage;
        public Action onMoved;
    }
}