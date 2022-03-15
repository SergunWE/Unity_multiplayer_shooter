using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Damage")]
public class WeaponDamage : ScriptableObject
{
    [SerializeField] private int baseDamage;
    [SerializeField] private float distanceDamageCoefficient = 1;

    [Header("Damage reduction interval")] 
    [SerializeField] private int startInterval;
    [SerializeField] private int endInterval;

    [Header("The number of bullets fired per round")] 
    [SerializeField] private int numberBullets = 1;

    public int NumberBullets => numberBullets;

    public int StartInterval => startInterval;
    public int EndInterval => endInterval;
    public int BaseDamage => baseDamage;
    public float DistanceDamageCoefficient => distanceDamageCoefficient;
}