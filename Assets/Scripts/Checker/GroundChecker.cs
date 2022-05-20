using System;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : Checker
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerCheck;

    //количество коллайдеров в месте проверки земли
    private Collider[] _colliders;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        //всегда есть 1 коллайдер - игрок, поэтому, если мы обнаруживаем больше 1 - 
        //мы можем прыгать. Записывать все входящие коллайдеры не обязательно, поэтому сделал
        //размером 2 - игрок и любой другой.
        //Добавился дополнительный коллайдер для проверки
        _colliders = new Collider[3];
    }

    private void Update()
    {
        UpdateState();
    }

    protected override bool Check()
    {
        return Physics.OverlapSphereNonAlloc(_transform.position, radius, _colliders, layerCheck) > 0;
    }
}