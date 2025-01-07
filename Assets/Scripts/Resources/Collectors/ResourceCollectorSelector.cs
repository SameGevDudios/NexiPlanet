using UnityEngine;

public class ResourceCollectorSelector : MonoBehaviour
{
    private enum CollectModes { Conditional, Temporal }
    [SerializeField] private CollectModes _collectMode;
    [SerializeField] private GameObject _conditionalButton, _conditionalCollector, _temporalCollector;
    private void Awake()
    {
        SelectMode();
    }

    private void SelectMode()
    {
        _conditionalButton.SetActive(_collectMode == CollectModes.Conditional);
        _conditionalCollector.SetActive(_collectMode == CollectModes.Conditional);
        _temporalCollector.SetActive(_collectMode == CollectModes.Temporal);
    }
}
