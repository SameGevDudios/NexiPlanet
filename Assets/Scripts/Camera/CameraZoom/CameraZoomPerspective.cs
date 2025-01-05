using UnityEngine;

public class CameraZoomPerspective : CameraZoom
{
    public CameraZoomPerspective(Camera cam) : base(cam)
    {
        _zoomSpeed *= 4;
        _zoomLimit = new Limit(30, 100);
    }
    protected override void SelectCameraMode()
    {
        _cam.orthographic = false;
    }
    protected override void Rotation()
    {
        _cam.transform.localEulerAngles = Vector3.right
            * Mathf.Lerp(
            _rotationLimit.Min,
            _rotationLimit.Max,
            (_cam.fieldOfView - _zoomLimit.Min) / (_zoomLimit.Max - _zoomLimit.Min)
            );
    }
    protected override void UpdateZoom()
    {
        _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, _currentZoom, _lerpSpeed * Time.deltaTime);
    }
}
