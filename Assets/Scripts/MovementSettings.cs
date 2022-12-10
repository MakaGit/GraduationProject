using UnityEngine;

[CreateAssetMenu(fileName = nameof(MovementSettings), menuName = "Settings/" + nameof(MovementSettings), order = 1)]
public class MovementSettings : ScriptableObject
{
    [SerializeField][Range(0f, 1f)] private float lerpSpeed;
    [SerializeField] private float maxSpeed;

    public float LerpSpeed => lerpSpeed;
    public float MaxSpeed => maxSpeed;
}
