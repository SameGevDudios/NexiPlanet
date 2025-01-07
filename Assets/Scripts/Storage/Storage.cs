// This class should've been an abstract one, but [System.Serializable] attribute, which is necessary for unity editor, is incompatible with such classes.
// So basically, that's an abstraction layer without abstractions.

public class Storage
{
    public string Type { get; protected set; }
    public int Count { get; protected set; }
    public Storage(string type)
    {
        Type = type;
    }
    public virtual void AddResource(int count)
    {

    }
    public void RemoveResource(int count)
    {
        Count -= count;
    }
    public bool CanRemove(int count) =>
        Count <= count;
}
