using System;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private List<ParticleSystem> confettiParticles;

    public event Action OnLevelEnd;
    private bool hasTriggered;

    private void Start()
    {
        //meshRenderer.enabled = false;
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

    public void PlayAnimation()
    {
        foreach (var particle in confettiParticles)
        {
            particle.Play();
        }
    }
}
