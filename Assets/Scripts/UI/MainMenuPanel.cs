using Zenject;

public class MainMenuPanel : UIPanel
{
    private LevelLoader levelLoader;
    private SaveSystem saveSystem;

    [Inject]
    private void Constructor(LevelLoader levelLoader, SaveSystem saveSystem)
    {
        this.levelLoader = levelLoader;
        this.saveSystem = saveSystem;
    }

    public void StartGameButtonClick()
    {
        int maxLevel = saveSystem.GetMaxUnlockedLevel();
        levelLoader.LoadScene(maxLevel);
    }
}
