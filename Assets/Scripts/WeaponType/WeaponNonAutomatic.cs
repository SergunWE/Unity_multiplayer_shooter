using System;
using System.Collections;
using UnityEngine;

public class WeaponNonAutomatic : Weapon
{
    public override void Use()
    {
        Shoot();
    }
}
