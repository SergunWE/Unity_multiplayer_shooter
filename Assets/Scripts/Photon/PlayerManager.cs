using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    private PhotonView _photonView;
    private GameObject _playerController;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        
        
    }

    void Start()
    {
        if (_photonView.IsMine)
        {
            CreateController();
        }
    }

    private void CreateController() 
    {
        //создаём экземпляр контроллера игрока
        Debug.Log("Instantiated Player Controller");
        _playerController = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), 
            Vector3.zero, Quaternion.identity, 0, new object[]{_photonView.ViewID});
    }

    public void Die()
    {
        PhotonNetwork.Destroy(_playerController);
        CreateController();
    }
}
