using UnityEngine;

namespace GameCore.LittleTricks.Curves
{
    public static class BezierCalculator
    {
        public static Vector3 CalculatePosition(Vector3 start, Vector3 inflection, Vector3 end, float t)
        {
            return Mathf.Pow((1 - t), 2) * start 
                   + 2 * t * (1 - t) * inflection 
                   + Mathf.Pow(t, 2) * end;
        }
    }
}