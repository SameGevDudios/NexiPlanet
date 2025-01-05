[System.Serializable]
public struct Limit
{
    public float Min, Max;
    public Limit(float min, float max)
    {
        Min = min;
        Max = max;
    }
}
