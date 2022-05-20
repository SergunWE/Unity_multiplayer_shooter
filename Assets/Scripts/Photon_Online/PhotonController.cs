using Photon.Pun;
using UnityEngine;

public class PhotonController : MonoBehaviour
{
    [SerializeField] private Transform playerOnlineDisplay;
    [SerializeField] private Transform playerOnlineWeaponDisplay;

    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private CapsuleCollider playerCollider;

    private PhotonView _photonView;
    private PlayerManager _playerManager;
    
    private void Awake()
    {
        _photonView = GetComponentInParent<PhotonView>();

        if (_photonView.IsMine)
        {
            int modelNumber = playerOnlineDisplay.childCount;
            // GameObject[] models = new GameObject[modelNumber];

            for (int i = 0; i < modelNumber; i++)
            {
                Destroy(playerOnlineDisplay.GetChild(i).gameObject);
            }
            
            // foreach (var model in models)
            // {
            //     Destroy(model.gameObject);
            // }
            Destroy(playerOnlineWeaponDisplay.gameObject);
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
        if(_playerManager == null) return;
        _playerManager.DeathPlayer();
    }

    #endregion
    
}