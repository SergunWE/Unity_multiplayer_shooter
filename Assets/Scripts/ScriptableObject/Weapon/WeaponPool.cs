using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Weapon/WeaponPool")]
public class WeaponPool : ScriptableObject
{
    [SerializeField] private List<WeaponInfo> weaponInfos;

    private int _infoLength;

     private void Awake()
     {
         _infoLength = weaponInfos.Count;
     }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _infoLength = weaponInfos.Count;
    }
#endif
    
    public WeaponInfo GetRandomWeaponInfo()
    {
        if (_infoLength < 0)
        {
            throw new Exception("The array is empty, it is impossible to get an element");
        }
        return weaponInfos[Random.Range(0, _infoLength)];
    }

    public WeaponInfo GetWeaponByName(string weaponName)
    {
        return weaponInfos.Find(a => a.ItemName == weaponName);
    }
}
