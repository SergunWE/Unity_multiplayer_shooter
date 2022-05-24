using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class HealthPhoton : Health<IntegerVariable, IntegerConstant>
{
    protected PhotonView PhotonView;

    protected virtual void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
    }

    protected override void Start()
    {
        if (!PhotonView.IsMine) return;
        value.SetValue(maxValue);
    }

    [PunRPC]
    public override void RecordDamage(int damage)
    {
        if (!PhotonView.IsMine) return;
        value.SetValue(value - damage);
    }

    public override void CheckValue()
    {
        if (value.Value <= 0)
        {
            Death();
        }
    }

    protected override void Death()
    {
        Debug.Log("Death", this);
    }
}