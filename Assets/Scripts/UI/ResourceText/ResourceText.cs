public abstract class ResourceText
{
    public IResource.ResourceType Type { get; protected set; }
    public abstract void UpdateText(int count);
}
