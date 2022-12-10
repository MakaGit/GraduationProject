using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameMonoInstaller : MonoInstaller
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject uiManager;
    [SerializeField] private GameObject inputSystem;
    [SerializeField] private GameObject endLevelTrigger;
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject levelLoader;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInNewPrefab(playerPrefab).AsSingle().NonLazy();
        Container.Bind<UIManager>().FromComponentOn(uiManager).AsSingle().NonLazy();
        Container.Bind<InputSystem>().FromComponentInNewPrefab(inputSystem).AsSingle().NonLazy();
        Container.Bind<EndLevelTrigger>().FromComponentOn(endLevelTrigger).AsSingle().NonLazy();
        Container.Bind<GameController>().FromComponentInNewPrefab(gameController).AsSingle().NonLazy();
        Container.Bind<LevelLoader>().FromComponentInNewPrefab(levelLoader).AsSingle().NonLazy();
    }
}
