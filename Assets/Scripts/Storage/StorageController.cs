using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class StorageController : MonoBehaviour
{
    [SerializeField] private List<Storage> _storage;
    [SerializeField] private List<TMP_Text> _storageText;

    #region Singleton
    public static StorageController Instance;
    private void Awake() =>
        Instance = this;
    #endregion

    public void AddResource(string resourceType, int count)
    {
        FindStorageByType(resourceType).AddResource(count);
    }
    public void RemoveResource(string resourceType, int count)
    {
        FindStorageByType(resourceType).RemoveResource(count);
    }
    private Storage FindStorageByType(string resourceType)
    {
        foreach (var item in _storage)
            if (item.GetResourceType == resourceType)
                return item;
        Debug.LogError($"Storage for {resourceType} not found");
        return null;
    }
}
