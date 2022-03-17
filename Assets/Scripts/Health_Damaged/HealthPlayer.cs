using Photon.Pun;
using UnityEngine;

public class HealthPlayer : HealthPhoton
{
    [SerializeField] private GameEvent onPlayerDied;

    protected override void Start()
    {
        base.Start();
        if(!_photonView.IsMine) return;
        GameCanvas.Instance.UpdatePlayerHealth(_value, maxValue);
    }

    [PunRPC]
    public override void RecordDamage(int damage)
    {
        if(!_photonView.IsMine) return;
        base.RecordDamage(damage);
        GameCanvas.Instance.UpdatePlayerHealth(_value, maxValue, ValueColor.ColorDamage);
    }

    protected override void Death()
    {
        onPlayerDied.Raise();
    }
}
