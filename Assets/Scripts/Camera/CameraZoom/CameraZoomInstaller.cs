using UnityEngine;
using Zenject;

public class CameraZoomInstaller : MonoInstaller
{
    [SerializeField] private Camera _cam;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private bool _useOrthographic;
    public override void InstallBindings()
    {
        if (_useOrthographic)
            Container.Bind<CameraZoom>().To<CameraZoomOrthographic>().AsSingle().WithArguments(_cam, _playerInput);
        else
            Container.Bind<CameraZoom>().To<CameraZoomPerspective>().AsSingle().WithArguments(_cam, _playerInput);
        Container.Bind<CameraZoomController>().FromComponentInHierarchy().AsSingle();
    }
}
