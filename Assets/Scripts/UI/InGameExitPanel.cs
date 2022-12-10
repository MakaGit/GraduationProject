using Zenject;

public class InGameExitPanel : UIPanel
{
    private LevelLoader levelLoader;

    [Inject]
    private void Constructor(LevelLoader levelLoader)
    {
        this.levelLoader = levelLoader;
    }

    public void ExitToMenu()
    {
        levelLoader.LoadScene(0);
    }
}
