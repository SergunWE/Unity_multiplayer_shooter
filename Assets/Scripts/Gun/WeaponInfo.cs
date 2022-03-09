﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FPS/New Weapon")]
public class WeaponInfo : ItemInfo
{
    [SerializeField] private float damage;

    public float Damage => damage;
}
