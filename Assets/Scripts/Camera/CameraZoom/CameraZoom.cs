using UnityEngine;

public abstract class CameraZoom
{
    protected Camera _cam;
    protected float _zoomSpeed = -5f, _lerpSpeed = 20f, _currentZoom;
    protected Limit _zoomLimit, _rotationLimit = new Limit(45, 75);

    public CameraZoom(Camera cam)
    {
        _cam = cam;
        ResetZoom();
        SelectCameraMode();
    }
    public void OnUpdate()
    {
        ReadZoom();
        LimitZoom();
        Rotation();
        UpdateZoom();
    }
    private void ResetZoom()
    {
        _currentZoom = _zoomLimit.Min;
    }
    protected abstract void SelectCameraMode();
    private void ReadZoom()
    {
        _currentZoom += PlayerInput.Zoom * _zoomSpeed;
    }
    protected abstract void Rotation();
    private void LimitZoom()
    {
        _currentZoom = Mathf.Clamp(_currentZoom, _zoomLimit.Min, _zoomLimit.Max);
    }
    protected abstract void UpdateZoom();
}
