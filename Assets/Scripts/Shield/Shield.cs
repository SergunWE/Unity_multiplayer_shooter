using System;
using Photon.Pun;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    public void DestroyShield()
    {
        _photonView.RPC("DestroyObject", RpcTarget.All);
    }
    
    [PunRPC]
    public void DestroyObject()
    {
        Destroy(GetComponent<ChangingScaleCrouch>());
        Destroy(gameObject);
    }
}
