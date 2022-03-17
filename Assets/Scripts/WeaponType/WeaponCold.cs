using System.Collections;
using UnityEngine;

public class WeaponCold : Weapon
{
    protected Coroutine _waitingCoroutine;

    public override void Use()
    {
        if (_canUse)
        {
            onWeaponUse.Raise();
            Waiting(_shoot);
        }
    }
    
    public override void AlternateUse()
    {
        if (_canUse)
        {
            onWeaponAlternateUse.Raise();
            //для задержки альтаернативного использования используем значения перезарядки
            Waiting(_reload);
        }
    }

    public override void ShowWeapon()
    {
        onWeaponPulling.Raise();
        Waiting(_pulling);
        _weaponModelInGame.SetActive(true);
    }

    public override void HideWeapon()
    {
        _canUse = false;
        StopAllCoroutines();
        _waitingCoroutine = null;
        _weaponModelInGame.SetActive(false);
    }
    
    private void Waiting(float delay)
    {
        if (_waitingCoroutine == null)
        {
            _waitingCoroutine = StartCoroutine(WaitingCoroutine(delay));
        }
    }
    
    private IEnumerator WaitingCoroutine(float delay)
    {
        _canUse = false;
        yield return new WaitForSeconds(delay);
        _canUse = true;
        onWeaponReady.Raise();
        _waitingCoroutine = null;
    }
}
