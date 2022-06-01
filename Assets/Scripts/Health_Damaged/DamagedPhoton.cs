using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class DamagedPhoton : Damaged
{
    [SerializeField] protected HealthPhoton health;
    private PhotonView _healthPhotonView;


    private void Awake()
    {
        _healthPhotonView = health.GetComponent<PhotonView>();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _healthPhotonView.RPC("RecordDamage", RpcTarget.All, ActualDamage);
    }
}