using UnityEngine;

public class WeaponSniper : WeaponNonAutomatic
{
    private bool _inScope = false;

    public override void AlternateUse()
    {
        _inScope = !_inScope;

        if (_inScope)
        {
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
