using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoBehaviour
{
    [SerializeField] private Transform startPositon;

    private Player player;

    [Inject]
    private void Constructor(Player player)
    {
        this.player = player;
    }

    private void Start()
    {
        SetupPlayer();
    }

    private void SetupPlayer()
    {
        player.transform.position = startPositon.position;
        player.transform.rotation= startPositon.rotation;
    }
}
