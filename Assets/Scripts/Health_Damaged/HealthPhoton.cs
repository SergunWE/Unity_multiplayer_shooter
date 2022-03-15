using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class HealthPhoton : Health
{
    protected PhotonView _photonView;

    protected virtual void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    [PunRPC]
    public override void RecordDamage(int damage)
    {
        if(!_photonView.IsMine) return;
        base.RecordDamage(damage);
    }
}
