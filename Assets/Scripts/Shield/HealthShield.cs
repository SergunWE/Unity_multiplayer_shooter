using Photon.Pun;
using UnityEngine;

public class HealthShield : HealthPhoton
{
    [SerializeField] private GameEvent onShieldDestroyed;

    protected override void Start()
    {
        base.Start();
        GameCanvas.Instance.UpdateShieldHealth(_value, maxValue);
    }

    protected override void Death()
    { 
        onShieldDestroyed.Raise();
    }

    [PunRPC]
    public override void RecordDamage(int damage)
    {
        if(!_photonView.IsMine) return;
        base.RecordDamage(damage);
        GameCanvas.Instance.UpdateShieldHealth(_value, maxValue, ValueColor.ColorDamage);
    }
}
