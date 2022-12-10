using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ButtonInput : MonoBehaviour
{
    [SerializeField] private MovingDirections movingDirection;

    private InputSystem inputSystem;

    [Inject]
    private void Constructor(InputSystem inputSystem)
    {
        this.inputSystem = inputSystem;
    }

    public void OnButton(bool buttonState)
    {
        inputSystem.SetDirection(movingDirection, buttonState);
    }
}
