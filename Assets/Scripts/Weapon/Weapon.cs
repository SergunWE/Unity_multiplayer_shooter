using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] protected WeaponInfo weaponInfo;
    protected static WeaponGameEvents GameEvents;
    private GameObject _weaponModelInGame;

    protected Coroutine _startReloadingCoroutine;
    private Coroutine _waitingCoroutine;

    public int CurrentClip { get; protected set; }
    public int CurrentTotal { get; protected set; }

    protected bool CanUse;

    private void Awake()
    {
        if (weaponInfo == null) return;
        _weaponModelInGame = Instantiate(weaponInfo.Model.Model, transform);

        CurrentClip = weaponInfo.Ammunition.Clip;
        CurrentTotal = weaponInfo.Ammunition.Total;
    }

    public abstract override void Use();

    public virtual void UnUse()
    {
    }

    public override void AlternateUse()
    {
    }

    public void SetWeaponGameEvents(WeaponGameEvents events)
    {
        GameEvents = events;
    }

    public void SetWeaponInfo(WeaponInfo info)
    {
        weaponInfo = info;
        Awake();
    }

    public virtual void ShowWeapon()
    {
        _weaponModelInGame.SetActive(true);
        GameEvents.OnWeaponPulling();
        Waiting(weaponInfo.Delays.Pulling);
    }

    public virtual void HideWeapon()
    {
        CanUse = false;
        _weaponModelInGame.SetActive(false);
        StopAllCoroutines();
        _startReloadingCoroutine = null;
        _waitingCoroutine = null;
    }


    public WeaponInfo WeaponInfo => weaponInfo;

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
            GameEvents.OnWeaponReload();
            _startReloadingCoroutine = StartCoroutine(StartReloadingCoroutine());
        }
    }

    private IEnumerator WaitingCoroutine(float delay)
    {
        CanUse = false;
        yield return new WaitForSeconds(delay);
        CanUse = true;
        GameEvents.OnWeaponReady();
        _waitingCoroutine = null;
    }

    protected virtual IEnumerator StartReloadingCoroutine()
    {
        if (_waitingCoroutine != null)
        {
            StopCoroutine(_waitingCoroutine);
            _waitingCoroutine = null;
        }

        CanUse = false;
        yield return new WaitForSeconds(weaponInfo.Delays.Reload - weaponInfo.Delays.Pulling);
        ReplaceClip();
        yield return StartCoroutine(WaitingCoroutine(weaponInfo.Delays.Pulling));
        _startReloadingCoroutine = null;
    }

    protected virtual void ReplaceClip()
    {
        int cartridgesRequired = weaponInfo.Ammunition.Clip - CurrentClip;
        int cartridgesSpentReloading = Math.Min(cartridgesRequired, CurrentTotal);
        CurrentClip += cartridgesSpentReloading;
        CurrentTotal -= cartridgesSpentReloading;
        GameEvents.OnWeaponClipReplaced();
    }

    protected virtual void Shoot()
    {
        if (!CanUse || CurrentClip <= 0) return;
        CurrentClip--;
        GameEvents.OnWeaponUse();
        Waiting(weaponInfo.Delays.Shoot);
    }

    public virtual void Reload()
    {
        if (!CanUse) return;
        if (CurrentClip == weaponInfo.Ammunition.Clip || CurrentTotal <= 0) return;
        if (_startReloadingCoroutine == null)
        {
            StartReloading();
        }
    }
}