using System.Collections;
using UnityEngine;

public class WeaponShotgun : WeaponNonAutomatic
{
    private bool _isReloading;
    protected override void ReplaceClip()
    {
        if (CurrentTotal <= 0) return;
        CurrentClip++;
        CurrentTotal--;
        GameEvents.OnWeaponClipReplaced();
    }
    
    protected override IEnumerator StartReloadingCoroutine()
    {
        _isReloading = true;
        CanUse = false;
        while (CurrentClip < weaponInfo.Ammunition.Clip && CurrentTotal > 0)
        {
            yield return new WaitForSeconds(weaponInfo.Delays.Reload);
            if(!_isReloading) break;
            ReplaceClip();
            CanUse = true;
            yield return null;
        }
        _startReloadingCoroutine = null;
        GameEvents.OnWeaponReady();
    }
    
    protected override void Shoot()
    {
        if (!CanUse || CurrentClip <= 0) return;
        CurrentClip--;
        _isReloading = false;
        GameEvents.OnWeaponUse();
        Waiting(weaponInfo.Delays.Shoot);
        
    }
}
