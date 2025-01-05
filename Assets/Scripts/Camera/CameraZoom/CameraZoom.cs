using UnityEngine;

public class CameraZoom
{
    protected Camera _cam;
    private PlayerInput _playerInput;
    protected float _zoomSpeed = -5f, _lerpSpeed = 20f, _currentZoom;
    protected Limit _zoomLimit, _rotationLimit = new Limit(45, 75);

    public CameraZoom(Camera cam, PlayerInput playerInput)
    {
        _cam = cam;
        _playerInput = playerInput;
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
    protected virtual void SelectCameraMode()
    {
        
    }
    private void ReadZoom()
    {
        _currentZoom += _playerInput.Zoom * _zoomSpeed;
    }
    protected virtual void Rotation()
    {

    }
    private void LimitZoom()
    {
        _currentZoom = Mathf.Clamp(_currentZoom, _zoomLimit.Min, _zoomLimit.Max);
    }
    protected virtual void UpdateZoom()
    {

    }
}
