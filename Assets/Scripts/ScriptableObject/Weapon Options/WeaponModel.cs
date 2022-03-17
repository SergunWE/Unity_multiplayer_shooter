using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Model")]
public class WeaponModel : ScriptableObject
{
    [SerializeField] private GameObject model;
    [SerializeField] private Vector3 displacementBarrel = Vector3.zero;

    public GameObject Model => model;
    public Vector3 DisplacementBarrel => displacementBarrel;
}
