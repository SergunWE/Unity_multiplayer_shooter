using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    [SerializeField] protected WeaponInfo weaponInfo;

    protected bool _canUse;

    public abstract override void Use();
    public abstract override void AlternateUse();
    public abstract void Reload();
    public abstract void ShowWeapon();
    public abstract void HideWeapon();
}
