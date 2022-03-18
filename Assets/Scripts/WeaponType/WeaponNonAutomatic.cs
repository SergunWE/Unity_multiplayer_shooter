using System;
using System.Collections;
using UnityEngine;

public class WeaponNonAutomatic : Weapon
{
    private bool _isPulling;
    protected bool _isPressed;
    
    protected Coroutine _startReloadingCoroutine;
    protected Coroutine _waitingCoroutine;
    protected Coroutine _changeWeaponModelCoroutine;

    protected override void Awake()
    {
        base.Awake();
        
    }

    public override void Use()
    {
        _isPressed = true;
        Shoot();
    }

    public override void UnUse()
    {
        _isPressed = false;
    }
    
    // public override void AlternateUse()
    // {
    //     Debug.Log("AlternateUse");
    // }
    
    public override void Reload()
    {
        if(_isPulling) return;
        if (_currentClip != weaponInfo.Ammunition.Clip && _currentTotal > 0)
        {
            onWeaponReload.Raise();
            if (_startReloadingCoroutine == null)
            {
                StartReloading();
            }
        }
    }

    public override void ShowWeapon()
    {
        onWeaponPulling.Raise();
        Waiting(weaponInfo.Delays.Pulling);
        _isPulling = true;
        ChangeWeaponModel(true);
    }
    
    public override void HideWeapon()
    {
        _canUse = false;
        ChangeWeaponModel(false);
        
        StopAllCoroutines();
        _startReloadingCoroutine = null;
        _waitingCoroutine = null;
        _changeWeaponModelCoroutine = null;
    }


    protected virtual void Shoot()
    {
        if (!_canUse || _currentClip <= 0) return;
        onWeaponUse.Raise();
        _currentClip--;
        AmmunitionUpdate();
        Waiting(weaponInfo.Delays.Shoot);
        //StartCoroutine(WaitingCoroutine(weaponInfo.Delays.Shoot));
        
        
    }

    protected virtual void ReplaceClip()
    {
        int cartridgesRequired = weaponInfo.Ammunition.Clip - _currentClip;
        int cartridgesSpentReloading = Math.Min(cartridgesRequired, _currentTotal);
        _currentClip += cartridgesSpentReloading;
        _currentTotal -= cartridgesSpentReloading;
        AmmunitionUpdate();
    }

    protected void AmmunitionUpdate()
    {
        onAmmunitionUpdate.Raise();
    }

    protected void Waiting(float delay)
    {
        if (_waitingCoroutine == null)
        {
            _waitingCoroutine = StartCoroutine(WaitingCoroutine(delay));
        }
    }

    private void StartReloading()
    {
        if (_startReloadingCoroutine == null)
        {
            _startReloadingCoroutine = StartCoroutine(StartReloadingCoroutine());
        }
    }

    private void ChangeWeaponModel(bool active)
    {
        if (_changeWeaponModelCoroutine == null)
        {
            _changeWeaponModelCoroutine = StartCoroutine(ChangeWeaponModelCoroutine(active));
        }
    }

    private IEnumerator WaitingCoroutine(float delay)
    {
        _canUse = false;
        yield return new WaitForSeconds(delay);
        _canUse = true;
        _isPulling = false;
        onWeaponReady.Raise();
        _waitingCoroutine = null;
    }

    protected virtual IEnumerator StartReloadingCoroutine()
    {
        if (_waitingCoroutine != null)
        {
            StopCoroutine(_waitingCoroutine);
            _waitingCoroutine = null;
        }
        
        _canUse = false;
        yield return new WaitForSeconds(weaponInfo.Delays.Reload - weaponInfo.Delays.Pulling);
        ReplaceClip();
        yield return StartCoroutine(WaitingCoroutine(weaponInfo.Delays.Pulling));
        _startReloadingCoroutine = null;
    }

    private IEnumerator ChangeWeaponModelCoroutine(bool active)
    {
        _weaponModelInGame.SetActive(active);
        yield break;
    }
}
