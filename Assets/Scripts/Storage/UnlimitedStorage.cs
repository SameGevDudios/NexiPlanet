using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class UnlimitedStorage : Storage
{
    [SerializeField] private List<TMP_Text> _resourceText;
    public UnlimitedStorage(string Type) : base(Type)
    {

    }
    public override void AddResource(int count)
    {
        Count += count;
        OnCountChanged();
    }
    private void OnCountChanged()
    {
        for (int i = 0; i < _resourceText.Count; i++)
        {
            _resourceText[i].text = Count.ToString();
        }
    }
}
