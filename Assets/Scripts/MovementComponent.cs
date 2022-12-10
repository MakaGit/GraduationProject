using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MovementComponent : MonoBehaviour
{
    public static readonly Vector3[] vectorAxes = new Vector3[]
    {
        Vector3.up,

        Vector3.forward,
        Vector3.right,
        Vector3.back,
        Vector3.left,

        Vector3.zero
    };

    [SerializeField] private MovementSettings movementSettings;
    [SerializeField] private Rigidbody mainRigidbody;
    [SerializeField] private List<MovingDirections> allowedDirections;

    private MovingDirections currentDirection = MovingDirections.Zero;
    private InputSystem inputSystem;

    [Inject]
    private void Constructor(InputSystem inputSystem)
    {
        this.inputSystem = inputSystem;
        Prepare();
    }

    private void Prepare()
    {
        inputSystem.OnDirectionChanges += ChangeDirection;
    }

    private void FixedUpdate()
    {
        Move(vectorAxes[(int)currentDirection]);
    }

    private void OnDestroy()
    {
        inputSystem.OnDirectionChanges -= ChangeDirection;
    }

    private void ChangeDirection(MovingDirections newDirection)
    {
        if (allowedDirections.Contains(newDirection))
            currentDirection = newDirection;
    }

    private void Move(Vector3 direction)
    {
        Vector3 currentMoveVector = mainRigidbody.velocity;
        Vector3 moveVector = direction;
        moveVector = Vector3.Lerp(currentMoveVector, (moveVector * movementSettings.MaxSpeed), movementSettings.LerpSpeed);

        mainRigidbody.velocity = moveVector;
    }
}
