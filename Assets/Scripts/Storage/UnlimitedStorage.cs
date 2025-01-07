public class UnlimitedStorage : Storage
{
    public UnlimitedStorage(string Type) : base(Type)
    {

    }
    public override void AddResource(int count)
    {
        Count += count;
    }
}
