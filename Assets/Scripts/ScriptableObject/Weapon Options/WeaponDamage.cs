﻿using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Damage")]
public class WeaponDamage : ScriptableObject
{
    [SerializeField] private float baseDamage;
    [SerializeField] private float distanceDamageCoefficient = 1;

    [Header("Damage reduction interval")] 
    [SerializeField] private float startInterval;
    [SerializeField] private float endInterval;

    [Header("The number of bullets fired per round")] 
    [SerializeField] private int numberBullets = 1;

    public float GetDamageValue()
    {
        return baseDamage;
    }

    public float GetDamageValue(float distance)
    {
        if (distance < startInterval)
        {
            return GetDamageValue();
        }

        return baseDamage * (1 - Math.Max(GetDamageReductionFactor(distance), distanceDamageCoefficient));
    }

    private float GetDamageReductionFactor(float distance)
    {
        return (distanceDamageCoefficient) *
               ((distance - startInterval) / endInterval - startInterval);
    }

    public int NumberBullets => numberBullets;
}