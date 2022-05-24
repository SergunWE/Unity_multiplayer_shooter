using Photon.Pun;
using UnityEngine;

public class HealthShield : HealthPhoton
{
    [SerializeField] private GameEvent onShieldDestroyed;

    protected override void Start()
    {
        base.Start();
        if(!PhotonView.IsMine) return;
        //GameCanvas.Instance.UpdateShieldHealth(_value.Value, maxValue);
    }

    protected override void Death()
    {
        Debug.Log("ShieldDead");
        onShieldDestroyed.Raise();
    }

    [PunRPC]
    public override void RecordDamage(int damage)
    {
        if(!PhotonView.IsMine) return;
        base.RecordDamage(damage);
        //GameCanvas.Instance.UpdateShieldHealth(_value.Value, maxValue, ValueColor.ColorDamage);
    }
}
