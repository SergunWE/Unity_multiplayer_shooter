using System.Collections;
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
        while (_currentClip < weaponInfo.Ammunition.Clip && _currentTotal > 0)
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
        if (!_canUse || _currentClip <= 0) return;
        onWeaponUse.Raise();
        _currentClip--;
        AmmunitionUpdate();
        Waiting(weaponInfo.Delays.Shoot);
        _isReloading = false;
    }
}
