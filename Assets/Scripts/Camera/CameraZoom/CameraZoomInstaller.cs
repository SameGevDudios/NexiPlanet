using UnityEngine;
using Zenject;

public class CameraZoomInstaller : MonoInstaller
{
    [SerializeField] private Camera _cam;
    [SerializeField] private bool _useOrthographic;
    public override void InstallBindings()
    {
        if (_useOrthographic)
            Container.Bind<CameraZoom>().To<CameraZoomOrthographic>().AsSingle().WithArguments(_cam);
        else
            Container.Bind<CameraZoom>().To<CameraZoomPerspective>().AsSingle().WithArguments(_cam);
        Container.Bind<CameraZoomController>().FromComponentInHierarchy().AsSingle();
    }
}
