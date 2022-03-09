using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private GameEvent onPlayerDied;
    
    private PhotonView _photonView;

    private const float MAXHealth = 100f;
    private float _currentHealth = MAXHealth;

    private void Start()
    {

        //_playerManager = PhotonView.Find((int)_photonView.InstantiationData[0]).GetComponent<PlayerManager>();
    }

    public void TakeDamage(float damage)
    {
        if (_photonView != null)
        {
            Debug.Log("PhotonView Null", this);
            return;
        }
        _photonView.RPC("RPC_TakeDamagePlayer", RpcTarget.All, damage);
    }
    
    public void TakeDamagePhotonView(float damage)
    {
        _currentHealth -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Die");
        onPlayerDied.Raise();
    }
    
    public void SetPhotonView(PhotonView photonView)
    {
        _photonView = photonView;
    }
}
