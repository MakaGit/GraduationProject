using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class MainMenuMonoInstaller : MonoInstaller
{
    [SerializeField] private GameObject uIManager;
    [SerializeField] private GameObject levelLoader;

    public override void InstallBindings()
    {
        Container.Bind<UIManager>().FromComponentOn(uIManager).AsSingle().NonLazy();
        Container.Bind<LevelLoader>().FromComponentInNewPrefab(levelLoader).AsSingle().NonLazy();
    }
}
