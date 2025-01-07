public class LimitedStorage : UnlimitedStorage
{
    private int _limit;

    public LimitedStorage(string Type, int limit) : base(Type)
    {
        _limit = limit;
    }
    public override void AddResource(int count)
    {
        Count += UnityEngine.Mathf.Min(_limit, Count + count);
    }
}