using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhotonController : MonoBehaviour
{
    [SerializeField] private GameObject playerOnlineDisplay;
    [SerializeField] private GameObject playerOnlineWeaponDisplay;

    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private CapsuleCollider playerCollider;

    private PhotonView _photonView;

    [SerializeField] private PlayerManager _playerManager;
    
    private void Awake()
    {
        _photonView = GetComponentInParent<PhotonView>();

        if (_photonView.IsMine)
        {
            MeshRenderer[] models = playerOnlineDisplay.GetComponentsInChildren<MeshRenderer>();
            foreach (var model in models)
            {
                Destroy(model.gameObject);
            }
            Destroy(playerOnlineWeaponDisplay);
        }
        else
        {
            Destroy(playerRigidbody);
            Destroy(playerCollider);
            DeleteLocalComponents(transform.parent.gameObject);
        }
    }

    private void DeleteLocalComponents(GameObject component)
    {
        Transform[] components = component.GetComponentsInChildren<Transform>();
        foreach (var obj in components)
        {
            if (!obj.TryGetComponent(out OnlineComponent onlineComponent) 
                && !obj.TryGetComponent(out PhotonView photonView))
            {
                Destroy(obj.gameObject);
            }
        }
    }

    public void SetPlayerManager()
    {
        _playerManager = PhotonView.Find((int) _photonView.InstantiationData[0]).GetComponent<PlayerManager>();
        //_playerManager = playerManager;
    }

    #region GameEvent

    public void OnPlayerDied()
    {
        _playerManager.DeathPlayer();
    }

    #endregion
    
}