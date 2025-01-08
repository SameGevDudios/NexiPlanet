using UnityEngine;

public class Node : MonoBehaviour, IResource
{
    [SerializeField] private IResource.ResourceType _resourceType;
    private bool _connected;
    public void Collect()
    {
        if (_connected)
        {
            StorageController.Instance.AddResource(_resourceType, 1);
        }
    }
    public void Connect()
    {
        _connected = true;
        ResourceCollector.Instance.AddSource(this);
    }
}
