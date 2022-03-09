using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ShieldHealth : MonoBehaviour, IDamageable
{
    private PhotonView _photonView;

    private const float MAXHealthShield = 300f;
    private float _currentHealthShield = MAXHealthShield;
    public void TakeDamage(float damage)
    {
        Debug.Log("TakeDamageShield");
        _photonView.RPC("RPC_TakeDamageShield", RpcTarget.All, damage);
    }

    public void TakeDamagePhotonView(float damage)
    {
        _currentHealthShield -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_currentHealthShield <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        transform.localScale = Vector3.zero;
    }

    public void SetPhotonView(PhotonView photonView)
    {
        _photonView = photonView;
    }
}
