using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponShotCalculation : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private Transform shotPoint;

    private WeaponInfo _currentWeapon;
    private WeaponDamage _weaponDamage;

    private Ray _shotRay;
    private Vector3 _shotPointPosition;
    private Vector3 _shotPointForward;
    private Quaternion _shotPointRotation;

    private RaycastHit _hit;
    private int _shotDistance;
    private Color _shotColor;
    private int _shotMaxDistance;

    private CalculateDamage _calculateDamage;

    private void Awake()
    {
        _calculateDamage = new CalculateDamage();
    }

    private void CalculateSingleShot()
    {
        _shotMaxDistance = 1000;
        _shotColor = Color.green;
        if (CalculateShot())
        {
            InflictDamage();
        }
    }

    private void CalculateShotgun()
    {
        //подумать, как оптимизировать большое количество дробинок
        _shotMaxDistance = 500;
        int numberBullets = _currentWeapon.Damage.NumberBullets;
        for (int i = 0; i < numberBullets; i++)
        {
            Vector3 deviation3D = Random.insideUnitCircle * 5f;
            Quaternion rot = Quaternion.LookRotation(Vector3.forward * 100 + deviation3D);
            _shotPointForward = _shotPointRotation * rot * Vector3.forward;
            
            _shotColor = Color.yellow;
            if (CalculateShot())
            {
                InflictDamage();
            }
            
            
        }
    }

    private void CalculateCold()
    {
        _shotMaxDistance = _currentWeapon.Damage.StartInterval;
        _shotColor = Color.red;
        _shotMaxDistance = _currentWeapon.Damage.StartInterval;
        if (CalculateShot())
        {
            _shotDistance = -1;
            InflictDamage();
        }
    }

    private void InflictDamage()
    {
        if (_hit.collider == null)
        {
            Debug.LogError("No hit was detected");
            return;
        }
        int damage = _calculateDamage.GetDamageValue(_currentWeapon.Damage, _shotDistance);
        Debug.Log("Distance: " + _shotDistance + " Damage: " + damage);

        // Debug.Log(_calculateDamage);
        // Debug.Log(_shotDistance);
        // Debug.Log(_hit.transform);
        if (_shotDistance >= 0)
        {
            _hit.transform.gameObject.GetComponent<Damaged>()?.TakeDamage(damage);
            return;
        }

        _hit.transform.gameObject.GetComponent<Damaged>()?.TakeDamage(_currentWeapon.Damage.BaseDamage);
    }

    private void RefreshTransform()
    {
        _shotPointRotation = shotPoint.rotation;
        _shotPointPosition = shotPoint.position;
        _shotPointForward = shotPoint.forward;
        _shotRay.direction = _shotPointPosition;
        _shotRay.origin = _shotPointForward;
    }

    private void DrawLine(Color color)
    {
        Debug.DrawLine(_shotPointPosition, _hit.point, color, 8, true);
    }

    private bool CheckHit()
    {
        return Physics.Raycast(_shotPointPosition, _shotPointForward, out _hit, _shotMaxDistance);
    }

    private bool CalculateShot()
    {
        if (!CheckHit()) return false;
        _shotDistance = (int)Vector3.Distance(_shotPointPosition, _hit.point);
        DrawLine(_shotColor);
        return true;
    }

    #region GameEvent

    public void OnWeaponUse()
    {
        RefreshTransform();
        
        _currentWeapon = weaponManager.CurrentWeapon;
        switch (_currentWeapon.Type)
        {
            case WeaponInfo.WeaponType.SingleShot:
                CalculateSingleShot();
                break;
            case WeaponInfo.WeaponType.Shotgun:
                CalculateShotgun();
                break;
            case WeaponInfo.WeaponType.Cold:
                CalculateCold();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion
}