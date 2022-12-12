using Cinemachine;
using UnityEngine;
using Zenject;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private Player player;

    [Inject]
    private void Constructor(Player player)
    {
        this.player = player;
    }

    private void Start()
    {
        PrepareCamera();
    }

    private void PrepareCamera()
    {
        virtualCamera.Follow = player.transform;
    }
}
