using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponShotCalculation : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private Transform shotPoint;

    [SerializeField] private GameEvent onWeaponCalculateShot;

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
        
        if (_shotDistance >= 0)
        {
            int damage = _calculateDamage.GetDamageValue(_currentWeapon.Damage, _shotDistance);
            Debug.Log("Distance: " + _shotDistance + " Damage: " + damage);
            _hit.transform.gameObject.GetComponent<Damaged>()?.TakeDamage(damage);
        }
        else
        {
            _hit.transform.gameObject.GetComponent<Damaged>()?.TakeDamage(_currentWeapon.Damage.BaseDamage);
        }

        
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
        _shotDistance = _shotMaxDistance;
        if (!CheckHit())
        {
            onWeaponCalculateShot.Raise();
            return false;
        }
        _shotDistance = (int)Vector3.Distance(_shotPointPosition, _hit.point);
        onWeaponCalculateShot.Raise();
        
        return true;
    }

    public Vector3 HitPosition()
    {
        if (_hit.collider == null)
        {
            return _shotPointForward * _shotMaxDistance;
        }
        return _hit.point;
    }

    public int Distance => _shotDistance;

    #region GameEvent

    public void OnWeaponUse()
    {
        RefreshTransform();
        
        _currentWeapon = weaponManager.CurrentWeaponInfo;
        switch (_currentWeapon.Type)
        {
            case WeaponType.SingleShot:
                CalculateSingleShot();
                break;
            case WeaponType.Shotgun:
                CalculateShotgun();
                break;
            case WeaponType.Cold:
                CalculateCold();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    #endregion
}