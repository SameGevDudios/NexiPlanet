using UnityEngine;

public class BuildPlacer : MonoBehaviour
{
    [SerializeField] private LayerMask _placeBuildingMask, _proximityMask;
    [SerializeField] private Camera _cam;
    [SerializeField] private GameObject _buildingToPlace, _buildLightHolder;
    private GameObject _instantiatedBuilding;
    [SerializeField] private Light _buildLight;
    [SerializeField] private float _buildingProximity;
    private bool _correctPosition;

    private void Start()
    {
        InstantiateBuilding();
    }
    private void Update()
    {
        UpdateBuildingPosition();
        bool canPlace = _correctPosition && NoBuildingsNearby;
        UpdateBuildLight(canPlace);
        if (PlayerInput.Build && canPlace)
            PlaceBuilding();

    }
    private void InstantiateBuilding()
    {
        _instantiatedBuilding = Instantiate(_buildingToPlace);
    }
    private void UpdateBuildingPosition()
    {
        Ray camRay = _cam.ScreenPointToRay(PlayerInput.MousePosition);
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
        InstantiateBuilding();
        // BuyBuilding();
    }
    private bool NoBuildingsNearby =>
        Physics.OverlapSphere(_instantiatedBuilding.transform.position, _buildingProximity, _proximityMask).Length == 1;
}
