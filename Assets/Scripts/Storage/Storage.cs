using UnityEngine;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class Storage
{
    [SerializeField] private List<TMP_Text> _resourceText;
    [SerializeField] private string _resourceType;
    private int _count;
    public void AddResource(int count)
    {
        _count += count;
        OnCountChanged();
    }
    public void RemoveResource(int count)
    {
        _count -= count;
        OnCountChanged();
    }
    private void OnCountChanged()
    {
        for (int i = 0; i < _resourceText.Count; i++)
        {
            _resourceText[i].text = _count.ToString();
        }
    }
    public string GetResourceType => _resourceType;
    public int GetCount => _count;
}
