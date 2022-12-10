using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EndgamePopup : UIPanel
{
    private static string StarCountText = "/3";

    [SerializeField] private Text starCountText;

    private LevelLoader levelLoader;

    [Inject]
    private void Constructor(LevelLoader levelLoader)
    {
        this.levelLoader = levelLoader;
    }

    public void SetStarCount(int starCount)
    {
        starCountText.text = starCount.ToString() + StarCountText;
    }

    public void NextLevelButtonClick()
    {
        levelLoader.LoadNextScene();
    }

    public void ReloadLevel()
    {
        levelLoader.ReloadScene();
    }
}
