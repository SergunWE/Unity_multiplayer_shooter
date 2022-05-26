using System.Collections;
using UnityEngine;

public class WeaponCold : Weapon
{
    public override void Use()
    {
        if (!CanUse) return;
        GameEvents.OnWeaponUse();
        Waiting(weaponInfo.Delays.Shoot);
    }
    
    public override void AlternateUse()
    {
        if (!CanUse) return;
        GameEvents.OnWeaponAlternateUse();
        //для задержки альтаернативного использования используем значения перезарядки
        Waiting(weaponInfo.Delays.Reload);
    }

    public override void Reload()
    {
        
    }
}
