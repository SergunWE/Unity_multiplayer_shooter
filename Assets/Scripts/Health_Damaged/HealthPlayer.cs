using Photon.Pun;
using UnityEngine;

public class HealthPlayer : HealthPhoton
{
    [SerializeField] private GameEvent onPlayerDied;

    protected override void Death()
    {
        if(!PhotonView.IsMine) return;
        onPlayerDied.Raise();
    }
}
