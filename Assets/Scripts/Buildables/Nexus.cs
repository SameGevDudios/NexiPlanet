using UnityEngine;

public class Nexus : MonoBehaviour, IResource, IPlacable
{
    [SerializeField] private string _resourceType;
    public void Collect()
    {
        StorageController.Instance.AddResource(_resourceType, 1);
    }
    public void Place()
    {
        ResourceCollector.Instance.AddSource(this);
    }
}
