using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    private Weapon[] _items;
    private int _currentGunIndex = 0;

    [SerializeField] private GameEvent onPlayerChangedGun;

    private void Awake()
    {
        _items = GetComponentsInChildren<Weapon>();
        Debug.Log("Всего оружия " + _items.Length);
    }

    private void Start()
    {
        foreach (var item in _items)
        {
            item.HideWeapon();
        }

        EquipItem(0);
    }

    public void EquipItem(int index)
    {
        if (index >= _items.Length || index < 0) return;

        _items[_currentGunIndex].HideWeapon();

        _items[index].ShowWeapon();
        _currentGunIndex = index;
        Debug.Log("Выбрано оружие " + index, this);
        OnAmmunitionUpdate();
        onPlayerChangedGun.Raise();
    }

    private void NextItem()
    {
        if (_currentGunIndex >= _items.Length - 1)
        {
            EquipItem(0);
        }
        else
        {
            EquipItem(_currentGunIndex + 1);
        }
    }

    private void PreviousItem()
    {
        if (_currentGunIndex <= 0)
        {
            EquipItem(_items.Length - 1);
        }
        else
        {
            EquipItem(_currentGunIndex - 1);
        }
    }

    #region InputEvent

    public void OnSelectScroll(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        int axis = (int) context.ReadValue<float>();
        if (axis > 0)
        {
            NextItem();
        }
        else
        {
            PreviousItem();
        }
    }

    public void OnSelectFirstGun(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        EquipItem(0);
    }

    public void OnSelectSecondGun(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        EquipItem(1);
    }

    public void OnUse(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _items[_currentGunIndex].Use();
    }

    public void OnAlternateUse(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _items[_currentGunIndex].AlternateUse();
    }

    public void OnReload(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _items[_currentGunIndex].Reload();
    }

    #endregion

    #region GameEvent

    public void OnAmmunitionUpdate()
    {
        GameCanvas.Instance.UpdateAmmunition(_items[_currentGunIndex].CartridgesClip(),
            _items[_currentGunIndex].CartridgesTotal());
    }

    #endregion

    public int CurrentGunIndex => _currentGunIndex;
}