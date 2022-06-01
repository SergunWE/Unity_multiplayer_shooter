using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class WeaponManager : MonoBehaviour
{
    private readonly List<Weapon> _weapons = new List<Weapon>();
    private int _currentWeaponIndex = 0;

    [SerializeField] private Transform weaponsParent;

    [SerializeField] private GameEvent onWeaponChange;
    [SerializeField] private WeaponGameEvents weaponGameEvents;

    [SerializeField] private IntegerVariable clipBullet;
    [SerializeField] private IntegerVariable totalBullet;

    [SerializeField] private StringVariable weaponName;
    
    [SerializeField] private WeaponPool firstWeapon;
    [SerializeField] private WeaponPool secondWeapon;
    

    private Weapon _currentWeapon;

    [SerializeField] private PhotonView tpwPhotonView;

    private void Awake()
    {
        CreateWeapon(firstWeapon.GetRandomWeaponInfo());
        CreateWeapon(secondWeapon.GetRandomWeaponInfo());
    }

    private void Start()
    {
        InitializeWeapon();
        foreach (var weapon in _weapons)
        {
            weapon.HideWeapon();
        }

        EquipWeapon(0);
    }

    private void EquipWeapon(int index)
    {
        if (index >= _weapons.Count || index < 0) return;

        _currentWeapon.HideWeapon();
        _currentWeaponIndex = index;
        _currentWeapon = _weapons[index];
        _currentWeapon.ShowWeapon();
        
        onWeaponChange.Raise();
        
        OnClipBulletUpdate();
        OnTotalBulletUpdate();
        WeaponNameUpdate();

        tpwPhotonView.RPC("SwitchWeapon", RpcTarget.Others, index);
    }

    private void NextWeapon()
    {
        if (_currentWeaponIndex >= _weapons.Count - 1)
        {
            EquipWeapon(0);
        }
        else
        {
            EquipWeapon(_currentWeaponIndex + 1);
        }
    }

    private void PreviousWeapon()
    {
        if (_currentWeaponIndex <= 0)
        {
            EquipWeapon(_weapons.Count - 1);
        }
        else
        {
            EquipWeapon(_currentWeaponIndex - 1);
        }
    }

    private void CreateWeapon(WeaponInfo info)
    {
        var weaponObject = new GameObject
        {
            name = info.ItemName,
            transform =
            {
                parent = weaponsParent.transform,
                localPosition = Vector3.zero
            }
        };
        
        Type firingMode = info.GetFiringMode();
        var weapon = weaponObject.AddComponent(firingMode).GetComponent<Weapon>();
        weapon.SetWeaponInfo(info);
        _weapons.Add(weapon);
        
        tpwPhotonView.RPC("AddWeaponModel", RpcTarget.Others, info.ItemName);
    }

    private void InitializeWeapon()
    {
        //_weapons = weaponsParent.GetComponentsInChildren<Weapon>();
        Debug.Log("Всего оружия " + _weapons.Count);
        if (_weapons.Count == 0) return;
        _weapons[0].SetWeaponGameEvents(weaponGameEvents);
        _currentWeapon = _weapons[0];
    }

    private void WeaponNameUpdate()
    {
        weaponName.SetValue(_currentWeapon.WeaponInfo.ItemName);
    }

    #region InputEvent

    public void OnSelectScroll(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        int axis = (int) context.ReadValue<float>();
        if (axis > 0.0)
        {
            NextWeapon();
        }
        else
        {
            PreviousWeapon();
        }
    }

    public void OnSelectFirstGun(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        EquipWeapon(0);
    }

    public void OnSelectSecondGun(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        EquipWeapon(1);
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _weapons[_currentWeaponIndex].Use();
        }
        else
        {
            if (context.canceled)
            {
                _weapons[_currentWeaponIndex].UnUse();
            }
        }
        
    }

    public void OnAlternateUse(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _weapons[_currentWeaponIndex].AlternateUse();
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _weapons[_currentWeaponIndex].Reload();
    }

    #endregion

    #region GameEvent

    public void OnClipBulletUpdate()
    {
        clipBullet.SetValue(_weapons[_currentWeaponIndex].CurrentClip);
    }

    public void OnTotalBulletUpdate()
    {
        totalBullet.SetValue(_weapons[_currentWeaponIndex].CurrentTotal);
    }

    #endregion

    public WeaponInfo CurrentWeaponInfo => _currentWeapon.WeaponInfo;
}