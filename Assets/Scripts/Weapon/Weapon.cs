using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] protected WeaponInfo weaponInfo;

    protected bool _canUse;

    protected static GameEvent onWeaponPulling;
    protected static GameEvent onWeaponReady;
    protected static GameEvent onWeaponUse;
    protected static GameEvent onWeaponAlternateUse;
    protected static GameEvent onWeaponReload;
    protected static GameEvent onAmmunitionUpdate;
    
    protected GameObject _weaponModelInGame;
    
    protected int _currentClip;
    protected int _currentTotal;

    protected virtual void Awake()
    {
        _weaponModelInGame = Instantiate(weaponInfo.Model.Model, transform);

        _currentClip = weaponInfo.Ammunition.Clip;
        _currentTotal = weaponInfo.Ammunition.Total;
    }

    public abstract override void Use();
    public override void AlternateUse() {}
    public abstract void ShowWeapon();
    public abstract void HideWeapon();
    public virtual void UnUse() {}
    public virtual void Reload() {}
    
    public int CurrentClip => _currentClip;
    public int CurrentTotal => _currentTotal;
    public WeaponInfo WeaponInfo => weaponInfo;

    public void SetOnWeaponPulling(GameEvent gameEvent)
    {
        onWeaponPulling = gameEvent;
    }
    
    public void SetOnWeaponUse(GameEvent gameEvent)
    {
        onWeaponUse = gameEvent;
    }
    
    public void SetOnWeaponAlternateUse(GameEvent gameEvent)
    {
        onWeaponAlternateUse = gameEvent;
    }
    
    public void SetOnWeaponReload(GameEvent gameEvent)
    {
        onWeaponReload = gameEvent;
    }
    
    public void SetOnWeaponReady(GameEvent gameEvent)
    {
        onWeaponReady = gameEvent;
    }
    
    public void SetOnAmmunitionUpdate(GameEvent gameEvent)
    {
        onAmmunitionUpdate = gameEvent;
    }
}
