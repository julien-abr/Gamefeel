using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InstallerManager : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<UpdateBehaviour>().FromNewComponentOnNewGameObject().AsSingle();
    }
}
