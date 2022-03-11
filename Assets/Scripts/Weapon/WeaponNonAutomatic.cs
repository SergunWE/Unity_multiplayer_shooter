using System;
using System.Collections;
using UnityEngine;

public class WeaponNonAutomatic : Weapon
{
    private int _cartridgesClip;
    private int _cartridgesTotal;

    private GameObject _weaponModel;

    private void Awake()
    {
        _cartridgesClip = weaponInfo.Ammunition.Clip;
        _cartridgesTotal = weaponInfo.Ammunition.Total;

        _weaponModel = Instantiate(weaponInfo.Model.Model, transform);

    }

    public override void Use()
    {
        Shoot();
    }
    
    public override void AlternateUse()
    {
        Debug.Log("AlternateUse");
    }
    
    public override void Reload()
    {
        if(!_canUse) return;
        if (_cartridgesClip != weaponInfo.Ammunition.Clip && _cartridgesTotal > 0)
        {
            onWeaponReload.Raise();
            StartCoroutine(StartReloading());
        }
    }

    public override void ShowWeapon()
    {
        onWeaponPulling.Raise();
        StartCoroutine(Waiting(weaponInfo.Delays.Pulling));
        StartCoroutine(ChangeWeaponModel(true));
    }
    
    public override void HideWeapon()
    {
        _canUse = false;
        StopAllCoroutines();
        
        StartCoroutine(ChangeWeaponModel(false));
    }


    private void Shoot()
    {
        if (_canUse && _cartridgesClip > 0)
        {
            onWeaponShot.Raise();
            _cartridgesClip--;
            AmmunitionUpdate();
            Debug.Log(_cartridgesClip + " " + _cartridgesTotal, this);
            StartCoroutine(Waiting(weaponInfo.Delays.Shoot));
        }
        // Debug.Log("SHOOT");
        // if(Physics.Raycast(shotPoint.position, shotPoint.forward, out RaycastHit hit))
        // {
        //     Vector3 start = new Vector3(shotPoint.position.x, shotPoint.position.y, shotPoint.position.z);
        //     Vector3 finish = new Vector3(hit.point.x,hit.point.y,hit.point.z);
        //     Debug.DrawLine(start, finish, Color.green, 100f, true);
        //     hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((WeaponInfo)itemInfo).Damage);
        // }
    }

    private void ReplaceClip()
    {
        int cartridgesRequired = weaponInfo.Ammunition.Clip - _cartridgesClip;
        int cartridgesSpentReloading = Math.Min(cartridgesRequired, _cartridgesTotal);
        _cartridgesClip += cartridgesSpentReloading;
        _cartridgesTotal -= cartridgesSpentReloading;
        AmmunitionUpdate();
    }

    private void AmmunitionUpdate()
    {
        onAmmunitionUpdate.Raise();
    }

    private IEnumerator Waiting(float delay)
    {
        _canUse = false;
        yield return new WaitForSeconds(delay);
        _canUse = true;
        onWeaponReady.Raise();
    }

    private IEnumerator StartReloading()
    {
        _canUse = false;
        yield return new WaitForSeconds(weaponInfo.Delays.Reload - weaponInfo.Delays.Pulling);
        ReplaceClip();
        yield return StartCoroutine(Waiting(weaponInfo.Delays.Pulling));
        //_canUse = true;
    }

    private IEnumerator ChangeWeaponModel(bool active)
    {
        _weaponModel.SetActive(active);
        yield break;
    }
    
    

    public override int CartridgesClip() => _cartridgesClip;
    public override int CartridgesTotal() => _cartridgesTotal;

    private void OnDisable()
    {
        
    }

    private void OnEnable()
    {
        //Debug.Log(weaponInfo.itemName);
        //AmmunitionUpdate();
        
        
    }
}
