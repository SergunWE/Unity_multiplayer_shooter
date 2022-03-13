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

    private void Awake()
    {
        _cartridgesClip = weaponInfo.Ammunition.Clip;
        _cartridgesTotal = weaponInfo.Ammunition.Total;

        _weaponModel = Instantiate(weaponInfo.Model.Model, transform);
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
        if (_cartridgesClip != weaponInfo.Ammunition.Clip && _cartridgesTotal > 0)
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
        if (!_canUse || _cartridgesClip <= 0) return;
        onWeaponUse.Raise();
        _cartridgesClip--;
        AmmunitionUpdate();
        Waiting(weaponInfo.Delays.Shoot);
        //StartCoroutine(WaitingCoroutine(weaponInfo.Delays.Shoot));
        
        
    }

    protected virtual void ReplaceClip()
    {
        int cartridgesRequired = weaponInfo.Ammunition.Clip - _cartridgesClip;
        int cartridgesSpentReloading = Math.Min(cartridgesRequired, _cartridgesTotal);
        _cartridgesClip += cartridgesSpentReloading;
        _cartridgesTotal -= cartridgesSpentReloading;
        AmmunitionUpdate();
    }

    protected void AmmunitionUpdate()
    {
        onAmmunitionUpdate.Raise();
    }

    private void Waiting(float delay)
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
        _weaponModel.SetActive(active);
        yield break;
    }
}
