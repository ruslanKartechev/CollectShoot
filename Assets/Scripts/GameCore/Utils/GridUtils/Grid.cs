using UnityEngine;

namespace GameCore.Utils.GridUtils
{
    [System.Serializable]
    public class  Grid
    {
        public Vector3[,] GridPositions;
        
        public Transform CenterPosition;
        public float CellWidth;
        public float CellHeight;
        public int XCount;
        public int YCount;
        
        public Grid(Transform centerPosition, float cellWidth, float cellHeight, int xCount, int yCount)
        {
            CenterPosition = centerPosition;
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            XCount = xCount;
            YCount = yCount;
        }
        

        public Vector3[,] GenerateXZ()
        {
            GridPositions = new Vector3[XCount, YCount];
            var xMult = (float)XCount / 2;
            if (XCount % 2 == 0)
                xMult += 0.5f;
          
            var yMult = (float)YCount / 2;
            if (YCount % 2 == 0)
                yMult += 0.5f;
            var startPos = CenterPosition.position - xMult * CellWidth * CenterPosition.right
                                               - yMult * CellHeight * CenterPosition.forward;
            for (int i = 0; i < XCount; i++)
            {
                for (int k = 0; k < YCount; k++)
                {
                    var pos = startPos + (i + 1) * CellWidth * CenterPosition.right
                                            + (k + 1) * CellHeight * CenterPosition.forward;
                    GridPositions[i, k] = pos;
                }    
            }
            return GridPositions;
        }
    }
}