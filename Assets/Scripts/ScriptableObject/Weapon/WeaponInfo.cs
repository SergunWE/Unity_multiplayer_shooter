using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/New Weapon")]
public class WeaponInfo : ItemInfo
{
    [SerializeField] private WeaponDamage damage;
    [SerializeField] private WeaponDelays delays;
    [SerializeField] private WeaponAmmunition ammunition;
    [SerializeField] private WeaponModel model;

    [SerializeField] private WeaponType type;
    [SerializeField] private WeaponFiringMode firingMode;

    public WeaponDamage Damage => damage;
    public WeaponDelays Delays => delays;
    public WeaponAmmunition Ammunition => ammunition;
    public WeaponModel Model => model;
    public WeaponType Type => type;

    public Type GetFiringModeScript()
    {
        switch (firingMode)
        {
            case WeaponFiringMode.NonAutomatic:
                return typeof(WeaponNonAutomatic);
            case WeaponFiringMode.Automatic:
                return typeof(WeaponAutomatic);
            case WeaponFiringMode.Shotgun:
                return typeof(WeaponShotgun);
            case WeaponFiringMode.Sniper:
                return typeof(WeaponSniper);
            case WeaponFiringMode.Cold:
                return typeof(WeaponCold);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

public enum WeaponType
{
    SingleShot,
    Shotgun,
    Cold
}

public enum WeaponFiringMode
{
    NonAutomatic,
    Automatic,
    Shotgun,
    Sniper,
    Cold
}