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
        _canUse = false;
        while (_cartridgesClip < weaponInfo.Ammunition.Clip && _cartridgesTotal > 0)
        {
            yield return new WaitForSeconds(weaponInfo.Delays.Reload);
            if(!_isReloading) break;
            ReplaceClip();
            _canUse = true;
            yield return null;
        }
        _startReloadingCoroutine = null;
        onWeaponReady.Raise();
    }
    
    protected override void Shoot()
    {
        if (!_canUse || _cartridgesClip <= 0) return;
        onWeaponUse.Raise();
        _cartridgesClip--;
        AmmunitionUpdate();
        Waiting(weaponInfo.Delays.Shoot);
        _isReloading = false;
    }
}
