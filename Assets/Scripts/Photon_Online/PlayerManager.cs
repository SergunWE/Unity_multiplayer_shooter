using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Photon.Pun;
using Random = UnityEngine.Random;

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
        //Debug.Log("Instantiated Player Controller");
        _playerController = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"),
            new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100))
            , Quaternion.identity, 0, new object[]{_photonView.ViewID});
        
        _playerController.GetComponentInChildren<PhotonController>().SetPlayerManager();
    }

    public void DeathPlayer()
    {
        PhotonNetwork.Destroy(_playerController);
        CreateController();
    }
}
