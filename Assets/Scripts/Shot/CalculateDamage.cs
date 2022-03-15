using UnityEngine;

public class CalculateDamage
{
    private static WeaponDamage _weaponDamage;
    private static int _startInterval;
    private static int _endInterval;
    private static int _distance;
    private static float _distanceDamageCoefficient;
    
    public int GetDamageValue(WeaponDamage weaponDamage, int distance)
    {
        _weaponDamage = weaponDamage;
        _startInterval = _weaponDamage.StartInterval;
        
        if (distance < _startInterval)
        {
            return _weaponDamage.BaseDamage;
        }
        
        _endInterval = _weaponDamage.EndInterval;
        _distance = distance;
        _distanceDamageCoefficient = _weaponDamage.DistanceDamageCoefficient;

        if (distance < _endInterval)
        {
            return (int) (_weaponDamage.BaseDamage * GetDamageReductionFactor());
        }

        return (int) (_weaponDamage.BaseDamage * _weaponDamage.DistanceDamageCoefficient);
    }

    private float GetDamageReductionFactor()
    {
        float factor = 1 - (float)(_distance - _startInterval) / (_endInterval - _startInterval);
        return Map(0, 1, _distanceDamageCoefficient, 1, factor);
    }

    private static float Map(float inMin, float inMax, float outMin, float outMax, float num)
        => outMin + (num - inMin) * (outMax - outMin) / (inMax - inMin);
}