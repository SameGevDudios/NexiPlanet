using UnityEngine;

public class ResourceCollectorTemporal : ResourceCollector
{
    [SerializeField] private float _collectInterval;

    private void Start()
    {
        Invoke("CollectAll", _collectInterval);
    }
    protected override void CollectAll()
    {
        base.CollectAll();
        Invoke("CollectAll", _collectInterval);
    }
}
