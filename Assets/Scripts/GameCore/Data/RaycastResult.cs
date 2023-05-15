﻿using UnityEngine;

namespace GameCore.Data
{
    public struct RaycastResult
    {
        public Collider Collider;
        public Vector3 Point;
        public Vector3 Normal;

        public RaycastResult(RaycastHit hit)
        {
            Collider = hit.collider;
            Point = hit.point;
            Normal = hit.normal;
        }
    }
}