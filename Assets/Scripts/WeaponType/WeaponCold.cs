using System.Collections;
using UnityEngine;

public class WeaponCold : Weapon
{
    protected Coroutine _waitingCoroutine;
    
    private void Awake()
    {
        _weaponModel = Instantiate(weaponInfo.Model.Model, transform);
        _cartridgesClip = _cartridgesTotal = 0;
    }

    public override void Use()
    {
        if (_canUse)
        {
            onWeaponUse.Raise();
            Debug.Log("Use Weapon Cold");
            Waiting(weaponInfo.Delays.Shoot);
        }
    }
    
    public override void AlternateUse()
    {
        if (_canUse)
        {
            onWeaponAlternateUse.Raise();
            Debug.Log("Alternate Use Weapon Cold");
            //для задержки альтаернативного использования используем значения перезарядки
            Waiting(weaponInfo.Delays.Reload);
        }
    }

    public override void ShowWeapon()
    {
        onWeaponPulling.Raise();
        Waiting(weaponInfo.Delays.Pulling);
        _weaponModel.SetActive(true);
    }

    public override void HideWeapon()
    {
        _canUse = false;
        StopAllCoroutines();
        _waitingCoroutine = null;
        _weaponModel.SetActive(false);
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
