using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShotCalculation : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private Transform shotPoint;

    [SerializeField] private LayerMask layerOnlinePlayers;
    [SerializeField] private float inspectionRadius;

    private WeaponInfo _currentWeapon;

    private void CalculateSingleShot()
    {
        if (Physics.Raycast(shotPoint.position, shotPoint.forward, out RaycastHit hit))
        {
            Vector3 start = shotPoint.position;
            Vector3 finish = hit.point;
            Debug.DrawLine(start, finish, Color.green, 3f, true);
        }
    }

    private void CalculateShotgun()
    {
        if (Physics.Raycast(shotPoint.position, shotPoint.forward, out RaycastHit hit1))
        {
            Vector3 start = shotPoint.position;
            Vector3 finish = hit1.point;
            float distance = Vector3.Distance(start, finish);
            Debug.Log(distance + " " + _currentWeapon.Damage.GetDamageValue(distance));
        }

        for (int i = 0; i < _currentWeapon.Damage.NumberBullets; i++)
        {
            //второй способ
            // Vector3 forwardVector = Vector3.forward;
            // float deviation = Random.Range(0f, 10);
            // float angle = Random.Range(0f, 360f);
            // forwardVector = Quaternion.AngleAxis(deviation, Vector3.up) * forwardVector;
            // forwardVector = Quaternion.AngleAxis(angle, Vector3.forward) * forwardVector;
            // forwardVector = shotPoint.transform.rotation * forwardVector;

            Vector3 deviation3D = Random.insideUnitCircle * 5f;
            Quaternion rot = Quaternion.LookRotation(Vector3.forward * 100 + deviation3D);
            Vector3 forwardVector = shotPoint.transform.rotation * rot * Vector3.forward;

            if (Physics.Raycast(shotPoint.position, forwardVector, out RaycastHit hit))
            {
                Vector3 start = shotPoint.position;
                Vector3 finish = hit.point;
                Debug.DrawLine(start, finish, Color.green, 10f, true);
            }
        }
    }

    private void CalculateCold()
    {
        Vector3 extents = Vector3.one * inspectionRadius;
        Physics.BoxCast(shotPoint.position, extents/2, shotPoint.forward, out RaycastHit closestHit, 
            Quaternion.Euler(0,0,0),
            _currentWeapon.Damage.StartInterval - inspectionRadius, layerOnlinePlayers,
            QueryTriggerInteraction.Collide);

        Ray ray = new Ray(shotPoint.position, shotPoint.forward);
        Physics.Raycast(ray, out var directHit, _currentWeapon.Damage.StartInterval, layerOnlinePlayers,
            QueryTriggerInteraction.Collide);

        if (directHit.collider != null)
        {
            Debug.Log("Direct");
            Debug.DrawLine(shotPoint.position, directHit.point, Color.red, 5f, true);
        }

        if (closestHit.collider != null)
        {
            Debug.Log("Closest");
            Debug.DrawLine(shotPoint.position, closestHit.point, Color.blue, 5f, true);
        }
    }

    #region GameEvent

    public void OnWeaponUse()
    {
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
        }
    }

    #endregion
}