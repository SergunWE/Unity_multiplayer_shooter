using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private ShieldHealth shieldHealth;

    private PhotonView _photonView;
    private PlayerManager _playerManager;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();

        shieldHealth.SetPhotonView(_photonView);
        playerHealth.SetPhotonView(_photonView);
    }

    private void Start()
    {
        if (FindObjectOfType<PlayerManager>())
            _playerManager = PhotonView.Find((int) _photonView.InstantiationData[0]).GetComponent<PlayerManager>();
    }

    [PunRPC]
    private void RPC_TakeDamageShield(float damage)
    {
        if (!_photonView.IsMine) return;
        shieldHealth.TakeDamagePhotonView(damage);
    }

    [PunRPC]
    private void RPC_TakeDamagePlayer(float damage)
    {
        if (!_photonView.IsMine) return;
        playerHealth.TakeDamagePhotonView(damage);
    }

    public void OnPlayerDied()
    {
        Debug.Log("Event Die");
        if (_photonView.IsMine)
        {
            _playerManager.Die();
        }
    }
}