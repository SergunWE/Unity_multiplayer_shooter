using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShotItem : Weapon
{
    [SerializeField] private Transform shotPoint;

    private MeshRenderer[] _meshRenderers;

    private void Awake()
    {
        _meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    public override void Use()
    {
        Shoot();
    }

    public override void ShowItem()
    {
        foreach (var model in _meshRenderers)
        {
            model.enabled = true;
        }
    }

    public override void HideItem()
    {
        foreach (var model in _meshRenderers)
        {
            model.enabled = false;
        }
    }

    private void Shoot()
    {
        Debug.Log("SHOOT");
        if(Physics.Raycast(shotPoint.position, shotPoint.forward, out RaycastHit hit))
        {
            Vector3 start = new Vector3(shotPoint.position.x, shotPoint.position.y, shotPoint.position.z);
            Vector3 finish = new Vector3(hit.point.x,hit.point.y,hit.point.z);
            Debug.DrawLine(start, finish, Color.green, 100f, true);
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((WeaponInfo)itemInfo).Damage);
        }
    }
    
    
}
