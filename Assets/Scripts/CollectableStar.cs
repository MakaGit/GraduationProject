using DG.Tweening;
using System.Collections;
using UnityEngine;
using Zenject;

public class CollectableStar : MonoBehaviour
{
    [SerializeField] private Collider trigger;

    [SerializeField] private ParticleSystem beamParticle;
    [SerializeField] private ParticleSystem glowParticle;
    [SerializeField] private ParticleSystem sparkleParticle;
    [SerializeField] private ParticleSystem shadowParticle;

    [SerializeField] private ParticleSystem confettiParticle;

    [SerializeField] private Transform startTransform;

    private GameController gameController;

    private bool isActive = true;

    [Inject]
    private void Container(GameController gameController)
    {
        this.gameController = gameController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
            return;

        isActive = false;
        trigger.enabled = false;

        gameController.StarCollected();
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        StartCoroutine(Animation());
    }    

    private IEnumerator Animation()
    {
        confettiParticle.Play();
        beamParticle.Stop();
        glowParticle.Stop();
        sparkleParticle.Stop();
        shadowParticle.Stop();  

        startTransform.DOScale(0f, 0.35f).SetEase(Ease.InQuart);

        yield return new WaitForSeconds(3f);

        gameObject.SetActive(false);
    }
}
