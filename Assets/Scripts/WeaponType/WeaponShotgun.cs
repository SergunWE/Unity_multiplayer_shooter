using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotgun : WeaponNonAutomatic
{
    private bool _isReloading;
    protected override void ReplaceClip()
    {
        if (_currentTotal <= 0) return;
        _currentClip++;
        _currentTotal--;
        AmmunitionUpdate();
    }
    
    protected override IEnumerator StartReloadingCoroutine()
    {
        _isReloading = true;
        _canUse = false;
        while (_currentClip < _clip && _currentTotal > 0)
        {
            yield return new WaitForSeconds(_reload);
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
        if (!_canUse || _currentClip <= 0) return;
        onWeaponUse.Raise();
        _currentClip--;
        AmmunitionUpdate();
        Waiting(_shoot);
        _isReloading = false;
    }
}
