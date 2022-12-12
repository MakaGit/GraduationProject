using Zenject;

public class InGameRestartPanel : UIPanel
{
    private LevelLoader levelLoader;

    [Inject]
    private void Constructor(LevelLoader levelLoader)
    {
        this.levelLoader = levelLoader;
    }

    public void OnRestartButtonClick()
    {
        levelLoader.ReloadScene();
    }
}
