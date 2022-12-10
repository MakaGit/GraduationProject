using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelGridElement : MonoBehaviour
{
    private static float noninteractableCanvasAlpha = 0.5f;
    private static string starText = "/3";

    [SerializeField] private Text levelCount;
    [SerializeField] private Text starCount;
    [SerializeField] private Button playButton;
    [SerializeField] private CanvasGroup canvasGroup;

    private LevelLoader levelLoader;

    private int level;

    [Inject]
    private void Constructor(LevelLoader levelLoader)
    {
        this.levelLoader = levelLoader;
    }

    public void SetLevelCount(int count)
    {
        level = count;
        levelCount.text = count.ToString();
    }

    public void SetStarCount(int count)
    {
        starCount.text = count.ToString() + starText;
    }

    public void SetInteractable(bool interactable)
    {
        playButton.interactable = interactable;
        canvasGroup.interactable = interactable;

        if (!interactable)
            canvasGroup.alpha = noninteractableCanvasAlpha;
        else
            canvasGroup.alpha = 1f;
    }

    public void StartLevel()
    {
        levelLoader.LoadScene(level);
    }
}
