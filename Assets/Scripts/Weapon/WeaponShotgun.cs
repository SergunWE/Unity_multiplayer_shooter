using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotgun : WeaponNonAutomatic
{
    private bool _isReloading;
    protected override void ReplaceClip()
    {
        if (_cartridgesTotal <= 0) return;
        _cartridgesClip++;
        _cartridgesTotal--;
        AmmunitionUpdate();
    }
    
    protected override IEnumerator StartReloadingCoroutine()
    {
        _isReloading = true;
        while (_cartridgesClip < weaponInfo.Ammunition.Clip && _cartridgesTotal > 0)
        {
            yield return new WaitForSeconds(weaponInfo.Delays.Reload);
            if(!_isReloading) break;
            ReplaceClip();
            yield return null;
        }
        _startReloadingCoroutine = null;
        onWeaponReady.Raise();
    }
    
    protected override void Shoot()
    {
        base.Shoot();
        _isReloading = false;
    }
}
