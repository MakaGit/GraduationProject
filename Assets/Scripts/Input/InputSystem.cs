using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private bool isActive = true;
    private bool isButtonPressed;
    private MovingDirections currentMovingDirection;

    public event Action<MovingDirections> OnDirectionChanges;

    public void SetDirection(MovingDirections movingDirection, bool buttonPressState)
    {
        if (!isActive)
            return;

        if (isButtonPressed && currentMovingDirection != movingDirection)
            return;

        if (buttonPressState)
            currentMovingDirection = movingDirection;
        else
            currentMovingDirection = MovingDirections.Zero;

        isButtonPressed = buttonPressState;
        OnDirectionChanges?.Invoke(currentMovingDirection);
    }

    public void SetActive(bool active)
    {
        isActive = active;

        if (!isActive)
        {
            OnDirectionChanges?.Invoke(MovingDirections.Zero);
            isButtonPressed = false;
        }
    }
}
