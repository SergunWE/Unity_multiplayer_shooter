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
    
    protected int _cartridgesClip;
    protected int _cartridgesTotal;

    protected GameObject _weaponModel;

    public abstract override void Use();
    public override void AlternateUse() {}
    public abstract void ShowWeapon();
    public abstract void HideWeapon();
    public virtual void UnUse() {}
    public virtual void Reload() {}
    
    public int CartridgesClip => _cartridgesClip;
    public int CartridgesTotal => _cartridgesTotal;

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
