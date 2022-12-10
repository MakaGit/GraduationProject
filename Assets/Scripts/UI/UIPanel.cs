using DG.Tweening;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    private static float fadeTime = 0.2f;

    [SerializeField] private CanvasGroup canvasGroup;

    private Tween fadeTween;
    private bool isActive;

    public void ShowPanel(bool active)
    {
        if (isActive == active)
            return;

        isActive = active;

        canvasGroup.interactable = isActive;
        canvasGroup.blocksRaycasts = isActive;

        if (fadeTween.IsActive())
            fadeTween.Complete();
        if (isActive)
            fadeTween = canvasGroup.DOFade(1f, fadeTime);
        else
            fadeTween = canvasGroup.DOFade(0f, fadeTime);
    }
}
