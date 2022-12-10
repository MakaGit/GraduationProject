using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CollectableStar : MonoBehaviour
{
    [SerializeField] private Collider trigger;

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
        gameObject.SetActive(false);
    }    
}
