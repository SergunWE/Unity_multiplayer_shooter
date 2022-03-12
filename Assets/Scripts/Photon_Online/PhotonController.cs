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
            if (!obj.TryGetComponent(out OnlineComponent onlineComponent))
            {
                Destroy(obj.gameObject);
            }
        }
    }
}