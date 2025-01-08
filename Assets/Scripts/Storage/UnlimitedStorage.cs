public class UnlimitedStorage : Storage
{
    public UnlimitedStorage(IResource.ResourceType Type) : base(Type)
    {

    }
    public override void AddResource(int count)
    {
        Count += count;
    }
}
