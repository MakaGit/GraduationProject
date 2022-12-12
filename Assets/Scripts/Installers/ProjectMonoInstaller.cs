using Zenject;
using UnityEngine;

public class ProjectMonoInstaller : MonoInstaller
{
    [SerializeField] private GameObject audioManager;

    public override void InstallBindings()
    {
        Container.Bind<SaveSystem>().AsSingle().NonLazy();
        Container.Bind<AudioManager>().FromComponentInNewPrefab(audioManager).AsSingle().NonLazy();
    }
}
