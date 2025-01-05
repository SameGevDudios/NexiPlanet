
using UnityEngine;

public class CameraZoomOrthographic : CameraZoom
{
    public CameraZoomOrthographic(Camera cam, PlayerInput playerInput) : base(cam, playerInput)
    {
        _zoomLimit = new Limit(4, 10);
    }
    protected override void SelectCameraMode()
    {
        _cam.orthographic = true;
    }
    protected override void Rotation()
    {
        _cam.transform.localEulerAngles = Vector3.right
            * Mathf.Lerp(
            _rotationLimit.Min,
            _rotationLimit.Max,
            (_cam.orthographicSize - _zoomLimit.Min) / (_zoomLimit.Max - _zoomLimit.Min)
            );
    }
    protected override void UpdateZoom()
    {
        _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, _currentZoom, _lerpSpeed * Time.deltaTime);
    }
}
