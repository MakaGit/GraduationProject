using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private EndLevelTrigger endLevelTrigger;
    private UIManager uIManager;
    private SaveSystem saveSystem;
    private InputSystem inputSystem;

    private int collectedStars;

    [Inject]
    private void Constructor(EndLevelTrigger endLevelTrigger, UIManager uIManager, SaveSystem saveSystem, InputSystem inputSystem)
    {
        this.endLevelTrigger = endLevelTrigger;
        this.uIManager = uIManager;
        this.saveSystem = saveSystem;
        this.inputSystem = inputSystem;
    }

    private void Start()
    {
        endLevelTrigger.OnLevelEnd += EndLevel;
    }

    private void OnDestroy()
    {
        endLevelTrigger.OnLevelEnd -= EndLevel;
    }

    private void EndLevel()
    {
        inputSystem.SetActive(false);

        if (collectedStars > 0)
        {
            uIManager.ActivateEndgamePopup(true, collectedStars);
            saveSystem.Save(collectedStars);
        }
        else
        {
            uIManager.ActivateEndgamePopup(false, collectedStars);
        }
    }

    public void StarCollected()
    {
        collectedStars++;
    }
}
