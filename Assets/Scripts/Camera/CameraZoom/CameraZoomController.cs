using UnityEngine;
using Zenject;

public class CameraZoomController : MonoBehaviour
{
    private CameraZoom _cameraZoom;

    [Inject]
    public void Constructor(CameraZoom cameraZoom)
    {
        _cameraZoom = cameraZoom;
    }
    void Update()
    {
        _cameraZoom.OnUpdate();
    }
}
