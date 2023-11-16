using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InstallerManager : MonoInstaller
{
    [SerializeField] private FlowerSpawnManager _flowerSpawnManager;
    
    public override void InstallBindings()
    {
        Container.Bind<UpdateBehaviour>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<FlowerSpawnManager>().FromInstance(_flowerSpawnManager).AsSingle();
    }
}
