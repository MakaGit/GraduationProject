using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StarCounter : MonoBehaviour
{
    [SerializeField] private Text countText;

    private SaveSystem saveSystem;

    [Inject]
    private void Construct(SaveSystem saveSystem)
    {
        this.saveSystem = saveSystem;
    }

    private void Start()
    {
        SetCount();
    }

    private void SetCount()
    {
        int count = saveSystem.GetMaxStarsCount();
        countText.text = count.ToString();
    }
}
