using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class BuildPlacer : MonoBehaviour
{
    [SerializeField] private LayerMask _placeBuildingMask, _proximityMask;
    [SerializeField] private Camera _cam;
    [SerializeField] private GameObject _buildLightHolder;
    private GameObject _currentSelected, _instantiatedBuilding;
    private IPlacable _currentBuilding;
    [SerializeField] private Light _buildLight;
    [SerializeField] private float _buildingProximity;
    private bool _correctPosition;
    [Inject] private IInput _input;

    private void Update()
    {
        if(_instantiatedBuilding != null && !EventSystem.current.IsPointerOverGameObject())
        {
            UpdateBuildingPosition();
            bool canPlace = _correctPosition && NoBuildingsNearby && _currentBuilding.CanPlace();
            UpdateBuildLight(canPlace);
            if (_input.Build() && canPlace)
                PlaceBuilding();
        }
    }
    private void InstantiateBuilding()
    {
        _instantiatedBuilding = Instantiate(_currentSelected);
        _currentBuilding = _instantiatedBuilding.GetComponent<IPlacable>();
    }
    private void UpdateBuildingPosition()
    {
        Ray camRay = _cam.ScreenPointToRay(_input.MousePosition());
        _correctPosition = Physics.Raycast(camRay, out RaycastHit hit, 100, _placeBuildingMask);
        if (_correctPosition)
        {
            _instantiatedBuilding.transform.position = hit.point;
            _buildLightHolder.transform.position = hit.point;
        }
    }
    private void UpdateBuildLight(bool canPlace)
    {
        _buildLight.color = canPlace ? Color.white : Color.red;
    }
    private void PlaceBuilding()
    {
        _currentBuilding.Place();
        InstantiateBuilding();
    }
    public void SetCurrentBuilding(GameObject building)
    {
        Destroy(_instantiatedBuilding);
        _buildLightHolder.SetActive(_currentSelected != building);
        if (_currentSelected != building)
        {
            _currentSelected = building;
            InstantiateBuilding();
        }
        else
        {
            _currentSelected = null;
        }
    }
    private bool NoBuildingsNearby =>
        Physics.OverlapSphere(_instantiatedBuilding.transform.position, _buildingProximity, _proximityMask).Length == 1;
}
