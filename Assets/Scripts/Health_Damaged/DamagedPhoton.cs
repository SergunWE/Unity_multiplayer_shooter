using Photon.Pun;


public class DamagedPhoton : Damaged
{
    private PhotonView _healthPhotonView;

    private void Awake()
    {
        _healthPhotonView = health.GetComponent<PhotonView>();
    }

    public override void TakeDamage(float damage)
    {
        float actualDamage = damage * damageMultiplier;
        _healthPhotonView.RPC("RecordDamage", RpcTarget.All, actualDamage);
    }
}
