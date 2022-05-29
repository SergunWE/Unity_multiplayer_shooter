using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Weapon/WeaponPool")]
public class WeaponPool : ScriptableObject
{
    [SerializeField] private WeaponInfo[] weaponInfos;

    private int _infoLength;

     private void Awake()
     {
         _infoLength = weaponInfos.Length;
     }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _infoLength = weaponInfos.Length;
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
}
