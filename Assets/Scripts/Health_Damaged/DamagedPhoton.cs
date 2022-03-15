using Photon.Pun;


public class DamagedPhoton : Damaged
{
    private PhotonView _healthPhotonView;

    private void Awake()
    {
        _healthPhotonView = health.GetComponent<PhotonView>();
    }

    public override void TakeDamage(int damage)
    {
        int actualDamage = (int)(damage * damageMultiplier);
        _healthPhotonView.RPC("RecordDamage", RpcTarget.All, actualDamage);
    }
}
