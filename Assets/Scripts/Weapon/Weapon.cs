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
    protected static GameEvent onWeaponShot;
    protected static GameEvent onWeaponReload;
    protected static GameEvent onAmmunitionUpdate;
    

    public abstract override void Use();
    public abstract override void AlternateUse();
    public abstract void Reload();
    public abstract void ShowWeapon();
    public abstract void HideWeapon();
    public abstract int CartridgesClip();
    public abstract int CartridgesTotal();

    public void SetOnWeaponPulling(GameEvent gameEvent)
    {
        onWeaponPulling = gameEvent;
    }
    
    public void SetOnWeaponShot(GameEvent gameEvent)
    {
        onWeaponShot = gameEvent;
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
