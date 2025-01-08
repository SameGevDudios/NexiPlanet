using UnityEngine;
using System.Collections.Generic;

public class StorageController : MonoBehaviour
{

    [System.Serializable]
    private struct StorageConfig
    {
        public IResource.ResourceType Type;
        public bool UseLimit;
        public int Limit;
    }

    [SerializeField] private List<StorageConfig> _storageConfig;
    private List<Storage> _storage = new();
    #region Singleton
    public static StorageController Instance;
    private void Awake() =>
        Instance = this;
    #endregion

    private void Start()
    {
        ConfigureStorages();
    }
    private void ConfigureStorages()
    {
        for (int i = 0; i < _storageConfig.Count; i++)
        {
            if (_storageConfig[i].UseLimit)
                _storage.Add(new LimitedStorage(_storageConfig[i].Type, _storageConfig[i].Limit));
            else
                _storage.Add(new UnlimitedStorage(_storageConfig[i].Type));
        }
    }
    public void AddResource(IResource.ResourceType resourceType, int count)
    {
        FindStorageByType(resourceType).AddResource(count);
    }
    public void RemoveResource(IResource.ResourceType resourceType, int count)
    {
        Storage currentStorage = FindStorageByType(resourceType);
        if (currentStorage.CanRemove(count))
            currentStorage.RemoveResource(count);
    }
    private Storage FindStorageByType(IResource.ResourceType resourceType)
    {
        foreach (Storage storage in _storage)
            if (storage.Type == resourceType)
                return storage;
        Debug.LogError($"Storage for {resourceType} not found");
        return null;
    }
}
