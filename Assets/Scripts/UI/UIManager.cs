using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIPanel mainPanel;
    [SerializeField] private EndgamePopup succesPanel;
    [SerializeField] private EndgamePopup failedPanel;

    [SerializeField] private SettingsPanel settingsPanel;

    public SettingsPanel SettingsPanel => settingsPanel;

    private void Start()
    {
        SetActiveUI(true);
    }

    public void SetActiveUI(bool active)
    {
        mainPanel.ShowPanel(active);
    }    

    public void ActivateEndgamePopup(bool levelSuccess, int starsCount)
    {
        succesPanel.SetStarCount(starsCount);
        failedPanel.SetStarCount(starsCount);

        if (levelSuccess)
            succesPanel.ShowPanel(true);
        else
            failedPanel.ShowPanel(true);
    }
}
