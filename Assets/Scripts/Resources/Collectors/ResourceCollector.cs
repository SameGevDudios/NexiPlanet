using UnityEngine;
using System.Collections.Generic;

public abstract class ResourceCollector : MonoBehaviour
{
    private List<IResource> _resource = new();

    #region Singleton
    public static ResourceCollector Instance;
    private void Awake() =>
        Instance = this;
    #endregion

    protected virtual void CollectAll()
    {
        foreach (IResource source in _resource)
        {
            source.Collect();
        }
    }
    public void AddSource(IResource newSource)
    {
        _resource.Add(newSource);
    }
}
