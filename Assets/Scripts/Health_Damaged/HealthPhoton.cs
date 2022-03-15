using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class HealthPhoton : Health
{
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    [PunRPC]
    public override void RecordDamage(float damage)
    {
        if(!_photonView.IsMine) return;
        base.RecordDamage(damage);
    }
}
