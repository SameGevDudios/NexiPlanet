public abstract class Storage
{
    public IResource.ResourceType Type { get; protected set; }
    public int Count { get; protected set; }
    public Storage(IResource.ResourceType type)
    {
        Type = type;
    }
    public abstract void AddResource(int count);
    public void RemoveResource(int count)
    {
        Count -= count;
    }
    public bool CanRemove(int count) =>
        Count <= count;
}
