﻿using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    private Weapon[] _weapons;
    private int _currentWeaponIndex = 0;

    [SerializeField] private GameEvent onWeaponChange;

    [SerializeField] private GameEvent onWeaponPulling;
    [SerializeField] private GameEvent onWeaponReady;
    [SerializeField] private GameEvent onWeaponUse;
    [SerializeField] private GameEvent onWeaponAlternateUse;
    [SerializeField] private GameEvent onWeaponReload;
    [SerializeField] private GameEvent onAmmunitionUpdate;

    private void Awake()
    {
        InitializeWeapon();

    }

    private void Start()
    {
        foreach (var weapon in _weapons)
        {
            weapon.HideWeapon();
        }

        EquipWeapon(0);
    }

    private void EquipWeapon(int index)
    {
        if (index >= _weapons.Length || index < 0) return;

        _weapons[_currentWeaponIndex].HideWeapon();

        _weapons[index].ShowWeapon();
        _currentWeaponIndex = index;
        //Debug.Log("Выбрано оружие " + index, this);
        OnAmmunitionUpdate();
        onWeaponChange.Raise();
    }

    private void NextWeapon()
    {
        if (_currentWeaponIndex >= _weapons.Length - 1)
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
            EquipWeapon(_weapons.Length - 1);
        }
        else
        {
            EquipWeapon(_currentWeaponIndex - 1);
        }
    }

    private void InitializeWeapon()
    {
        _weapons = GetComponentsInChildren<Weapon>();
        Debug.Log("Всего оружия " + _weapons.Length);
        
        if (_weapons == null) return;
        _weapons[0].SetOnWeaponPulling(onWeaponPulling);
        _weapons[0].SetOnWeaponReady(onWeaponReady);
        _weapons[0].SetOnWeaponUse(onWeaponUse);
        _weapons[0].SetOnWeaponAlternateUse(onWeaponAlternateUse);
        _weapons[0].SetOnWeaponReload(onWeaponReload);
        _weapons[0].SetOnAmmunitionUpdate(onAmmunitionUpdate);
    }

    #region InputEvent

    public void OnSelectScroll(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        int axis = (int) context.ReadValue<float>();
        if (axis > 0)
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

    public void OnAmmunitionUpdate()
    {
        GameCanvas.Instance.UpdateAmmunition(_weapons[_currentWeaponIndex].CartridgesClip,
            _weapons[_currentWeaponIndex].CartridgesTotal);
    }

    #endregion

    public int CurrentWeaponIndex => _currentWeaponIndex;
}