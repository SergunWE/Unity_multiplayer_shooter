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

    //Damage Caching
    protected int _baseDamage;
    protected float _distanceDamageCoefficient;
    protected int _startInterval;
    protected int _endInterval;
    protected int _numberBullets;
    
    //Delays Caching
    protected float _pulling;
    protected float _shoot;
    protected float _reload;
    
    //Ammunition Caching
    protected int _currentClip;
    protected int _currentTotal;

    protected int _clip;
    protected int _total;
    
    //Model Caching
    protected GameObject _model;
    protected Vector3 _displacementBarrel;

    //Type Caching
    protected WeaponType _type;

    protected virtual void Awake()
    {
        WeaponDamage wd = weaponInfo.Damage;
        _baseDamage = wd.BaseDamage;
        _distanceDamageCoefficient = wd.DistanceDamageCoefficient;
        _startInterval = wd.StartInterval;
        _endInterval = wd.EndInterval;
        _numberBullets = wd.NumberBullets;

        WeaponDelays wds = weaponInfo.Delays;
        _pulling = wds.Pulling;
        _shoot = wds.Shoot;
        _reload = wds.Reload;

        WeaponAmmunition wa = weaponInfo.Ammunition;
        _clip = wa.Clip;
        _total = wa.Total;

        WeaponModel wm = weaponInfo.Model;
        _model = wm.Model;
        _displacementBarrel = wm.DisplacementBarrel;

        _type = weaponInfo.Type;
        
        _weaponModelInGame = Instantiate(_model, transform);

        _currentClip = _clip;
        _currentTotal = _total;
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
