using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAutomatic : Weapon
{
    private bool _isPressed;
    private Coroutine _shootingCoroutine;

    public override void Use()
    {
        _isPressed = true;
        Shoot();
    }

    public override void UnUse()
    {
        _isPressed = false;
    }

    protected override void Shoot()
    {
        if (_shootingCoroutine == null)
        {
            _shootingCoroutine = StartCoroutine(ShootingCoroutine());
        }
    }

    private IEnumerator ShootingCoroutine()
    {
        while (_isPressed)
        {
            if (CanUse)
            {
                base.Shoot();
            }
            yield return null;
        }
        _shootingCoroutine = null;
    }

    public override void HideWeapon()
    {
        base.HideWeapon();
        _shootingCoroutine = null;
    }
}