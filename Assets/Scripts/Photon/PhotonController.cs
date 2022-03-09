using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhotonController : MonoBehaviour
{
    [SerializeField] private GameObject playerOnlineDisplay;
    
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private CapsuleCollider playerCapsuleCollider;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameEventListener gameEventListener;

    [SerializeField] private GameObject[] playerComponents;
    
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
        }
        else
        {
            Destroy(gameEventListener.gameObject);
            Destroy(playerRigidbody);
            Destroy(playerCapsuleCollider);
            Destroy(playerInput.gameObject);
            
            foreach (var component in playerComponents)
            {
                Destroy(component);
            }
            
        }
    }

    private void Start()
    {
    }
}