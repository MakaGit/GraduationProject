using Zenject;

public class ProjectMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SaveSystem>().AsSingle().NonLazy();
    }
}
