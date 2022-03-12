using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAutomatic : Weapon
{
    private bool _isShooting;

    private Coroutine _shootCoroutine;

    private void Awake()
    {
        _cartridgesClip = weaponInfo.Ammunition.Clip;
        _cartridgesTotal = weaponInfo.Ammunition.Total;

        _weaponModel = Instantiate(weaponInfo.Model.Model, transform);

        _isShooting = false;
    }

    public override void Use()
    {
        _isShooting = true;
        _shootCoroutine = StartCoroutine(Shoot());
    }

    public override void UnUse()
    {
        _isShooting = false;
        //StopCoroutine(_shootCoroutine);
    }

    public override void AlternateUse()
    {
        Debug.Log("AlternateUse");
    }

    public override void Reload()
    {
        if (!_canUse) return;
        if (_cartridgesClip != weaponInfo.Ammunition.Clip && _cartridgesTotal > 0)
        {
            onWeaponReload.Raise();
            StartCoroutine(StartReloading());
        }
    }

    public override void ShowWeapon()
    {
        onWeaponPulling.Raise();
        StartCoroutine(Waiting(weaponInfo.Delays.Pulling));
        StartCoroutine(ChangeWeaponModel(true));
    }

    public override void HideWeapon()
    {
        _canUse = false;
        StopAllCoroutines();

        StartCoroutine(ChangeWeaponModel(false));
    }


    private IEnumerator Shoot()
    {
        while (_isShooting)
        {
            if (_canUse && _cartridgesClip > 0)
            {
                onWeaponShot.Raise();
                _cartridgesClip--;
                AmmunitionUpdate();
                yield return StartCoroutine(Waiting(weaponInfo.Delays.Shoot));
            }
            
            yield return null;
        }
        
    }

    private void ReplaceClip()
    {
        int cartridgesRequired = weaponInfo.Ammunition.Clip - _cartridgesClip;
        int cartridgesSpentReloading = Math.Min(cartridgesRequired, _cartridgesTotal);
        _cartridgesClip += cartridgesSpentReloading;
        _cartridgesTotal -= cartridgesSpentReloading;
        AmmunitionUpdate();
    }

    private void AmmunitionUpdate()
    {
        onAmmunitionUpdate.Raise();
    }

    private IEnumerator Waiting(float delay)
    {
        _canUse = false;
        yield return new WaitForSeconds(delay);
        _canUse = true;
        onWeaponReady.Raise();
    }

    private IEnumerator StartReloading()
    {
        _canUse = false;
        yield return new WaitForSeconds(weaponInfo.Delays.Reload - weaponInfo.Delays.Pulling);
        ReplaceClip();
        yield return StartCoroutine(Waiting(weaponInfo.Delays.Pulling));
        //_canUse = true;
    }

    private IEnumerator ChangeWeaponModel(bool active)
    {
        _weaponModel.SetActive(active);
        yield break;
    }
}