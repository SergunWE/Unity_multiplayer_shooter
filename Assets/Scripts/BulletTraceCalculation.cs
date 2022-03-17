using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTraceCalculation : MonoBehaviour
{
    [SerializeField] private float disappearanceTime;
    
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private WeaponShotCalculation weaponShotCalculation;
    [SerializeField] private GameObject bulletTracePrefab;

    [SerializeField] private Transform cameraBulletTrace;
    
    private Vector3 _startingPoint;
    private Vector3 _endingPoint;
    
    private Color _startColor;
    private Color _endColor;

    private WeaponInfo _weaponInfo;

    private void Awake()
    {
        LineRenderer lineSettings = bulletTracePrefab.GetComponent<LineRenderer>();
        _startColor = lineSettings.startColor;
        _endColor = lineSettings.endColor;

    }

    private void CreateTrace()
    {
        LineRenderer line = Instantiate(bulletTracePrefab, transform).GetComponent<LineRenderer>();
        line.SetPosition(0, _startingPoint);
        line.SetPosition(1,_endingPoint);
        cameraBulletTrace.transform.localPosition = _weaponInfo.Model.DisplacementBarrel;
        StartCoroutine(DisappearanceTrace(line));
    }
    
    private IEnumerator DisappearanceTrace(LineRenderer line)
    {
        float t = 0;
        while (t < 1)
        {
            line.startColor = Color.Lerp(_startColor, Color.clear, t);
            line.endColor = Color.Lerp(_endColor, Color.clear, t);
            t += Time.deltaTime / disappearanceTime;
            yield return null;
        }
        Destroy(line.gameObject);
    }

    public void OnWeaponCalculateShot()
    {
        if(weaponManager.CurrentWeaponInfo.Type == WeaponInfo.WeaponType.Cold) return;
        if(weaponShotCalculation.Distance < 1) return;
        _weaponInfo = weaponManager.CurrentWeaponInfo;
        _startingPoint = weaponManager.BarrelPosition();
        _endingPoint = weaponShotCalculation.HitPosition();

        CreateTrace();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
