using System;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;

    public event Action OnLevelEnd;
    private bool hasTriggered;

    private void Start()
    {
        meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered)
            LevelEnd();
    }

    private void LevelEnd()
    {
        hasTriggered = true;
        OnLevelEnd?.Invoke();
    }
}
