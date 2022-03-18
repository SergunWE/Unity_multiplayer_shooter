using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Model")]
public class WeaponModel : ScriptableObject
{
    [SerializeField] private GameObject model;

    public GameObject Model => model;
}
