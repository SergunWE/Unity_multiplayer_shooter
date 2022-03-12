using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAutomatic : WeaponNonAutomatic
{
    private Coroutine _shootingCoroutine;

    protected override void Shoot()
    {
        Shooting();
    }

    private void Shooting()
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
            if (_canUse)
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