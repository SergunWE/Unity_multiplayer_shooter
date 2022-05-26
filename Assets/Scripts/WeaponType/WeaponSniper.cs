using UnityEngine;

public class WeaponSniper : WeaponNonAutomatic
{
    private bool _inScope = false;

    public override void AlternateUse()
    {
        if(!CanUse) return;
        _inScope = !_inScope;
        if (!_inScope) return;
        GameEvents.OnWeaponAlternateUse();
        Debug.Log("Sniper scope");
    }

    public override void ShowWeapon()
    {
        _inScope = false;
        base.ShowWeapon();
    }

    public override void HideWeapon()
    {
        _inScope = false;
        base.HideWeapon();
    }
}
