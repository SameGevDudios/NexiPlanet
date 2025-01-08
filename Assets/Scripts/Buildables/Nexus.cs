using UnityEngine;

public class Nexus : MonoBehaviour, IResource, IPlacable
{
    [SerializeField] protected IResource.ResourceType _resourceType;
    public virtual void Collect()
    {
        // Mock
        print("Collected resource");
    }
    public void Place()
    {
        ResourceCollector.Instance.AddSource(this);
    }
    public bool CanPlace()
    {
        // Mock
        return true;
    }
}
