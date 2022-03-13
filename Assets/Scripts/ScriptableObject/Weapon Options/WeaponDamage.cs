using System;
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

        if (distance < endInterval)
        {
            return baseDamage * GetDamageReductionFactor(distance);
        }
        
        return baseDamage * distanceDamageCoefficient;
    }

    private float GetDamageReductionFactor(float distance)
    {
        float factor = 1 - ((distance - startInterval) / (endInterval - startInterval));
        
        return Map(0, 1, distanceDamageCoefficient,1,factor);
    }
    
    static float Map(float in_min, float in_max, float out_min, float out_max, float num) 
        => out_min + (num - in_min) * (out_max - out_min) / (in_max - in_min);

    public int NumberBullets => numberBullets;

    public float StartInterval => startInterval;
}