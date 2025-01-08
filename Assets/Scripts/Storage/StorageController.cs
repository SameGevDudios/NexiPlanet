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
    [SerializeField] private ResourceTextController _resourceTextController;
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
        foreach(StorageConfig config in _storageConfig)
        {
            if (config.UseLimit)
                _storage.Add(new LimitedStorage(config.Type, config.Limit));
            else
                _storage.Add(new UnlimitedStorage(config.Type));
        }
    }
    public void AddResource(IResource.ResourceType resourceType, int count)
    {
        Storage currentStorage = FindStorageByType(resourceType);
        currentStorage.AddResource(count);
        _resourceTextController.UpdateResourceText(resourceType, currentStorage.Count);
    }
    public void RemoveResource(IResource.ResourceType resourceType, int count)
    {
        Storage currentStorage = FindStorageByType(resourceType);
        if (currentStorage.CanRemove(count))
        {
            currentStorage.RemoveResource(count);
            _resourceTextController.UpdateResourceText(resourceType, currentStorage.Count);
        }
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
