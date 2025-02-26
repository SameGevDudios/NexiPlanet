using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInput>().To<PlayerInput>().AsSingle();
    }

}
