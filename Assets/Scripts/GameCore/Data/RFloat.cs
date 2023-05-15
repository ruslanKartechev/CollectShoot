namespace GameCore.Data
{
    [System.Serializable]
    public class RFloat
    {
        public float Min;
        public float Max;

        public float Value => UnityEngine.Random.Range(Min, Max);
    }
}