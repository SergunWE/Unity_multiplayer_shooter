using UnityEngine;

public class WeaponSniper : WeaponNonAutomatic
{
    private bool _inScope = false;

    public override void AlternateUse()
    {
        if(!_canUse) return;
        _inScope = !_inScope;

        if (_inScope)
        {
            onWeaponAlternateUse.Raise();
            Debug.Log("Sniper scope");
        }
    }

    public override void ShowWeapon()
    {
        base.ShowWeapon();
        _inScope = false;
    }

    public override void HideWeapon()
    {
        base.HideWeapon();
        _inScope = false;
    }
}
