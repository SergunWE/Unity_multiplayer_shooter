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

    public WeaponDamage Damage => damage;
    public WeaponDelays Delays => delays;
    public WeaponAmmunition Ammunition => ammunition;
    public WeaponModel Model => model;
}
