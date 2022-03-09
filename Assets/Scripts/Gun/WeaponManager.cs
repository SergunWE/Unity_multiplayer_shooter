using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    private Item[] _items;
    private int _currentGunIndex = 0;

    [SerializeField] private GameEvent onPlayerChangedGun;

    private void Awake()
    {
        _items = GetComponentsInChildren<Item>();
        Debug.Log(_items.Length);
        //EquipItem(0);
    }

    private void Start()
    {
        EquipItem(0);
    }

    public void EquipItem(int index)
    {
        if (index >= _items.Length || index < 0) return;

        _items[_currentGunIndex].HideItem();

        _items[index].ShowItem();
        _currentGunIndex = index;
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

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _items[_currentGunIndex].Use();
    }

    public int CurrentGunIndex => _currentGunIndex;
}