using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class TpWeapon : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform weaponsParent;
    [SerializeField] private WeaponPool weaponPool;

    private readonly List<GameObject> _weaponModels = new List<GameObject>();
    private PhotonView _photonView;
    
    private int _currentWeaponIndex = 0;
    private GameObject _currentWeapon;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void EquipWeapon(int index)
    {
        if (index >= _weaponModels.Count || index < 0) return;

        _currentWeapon.SetActive(false);
        _currentWeaponIndex = index;
        _currentWeapon = _weaponModels[index];
        _currentWeapon.SetActive(true);
    }

    [PunRPC]
    public void SwitchWeapon(int index)
    {
        if(_photonView == null && _photonView.IsMine || _weaponModels.Count == 0) return; 
        EquipWeapon(index);
    }

    [PunRPC]
    public void AddWeaponModel(string weaponName)
    {
        if(_photonView == null && _photonView.IsMine) return;
        var weaponObject = SetWeaponModel(weaponPool.GetWeaponByName(weaponName).Model.Model);
        _weaponModels.Add(weaponObject);
        _currentWeapon = _weaponModels[0];
    }

    private GameObject SetWeaponModel(GameObject model)
    {
        var weaponObject = Instantiate(model, weaponsParent);
        weaponObject.layer = 0;
        foreach (var child in weaponObject.GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = 0;
        }
        weaponObject.SetActive(false);
        return weaponObject;
    }
}
