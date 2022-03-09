using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Spread")]
public class WeaponSpread : ScriptableObject
{
    //разброс
    [SerializeField] private float baseSpread;
    [SerializeField] private float maximumSpread;

    [SerializeField] private float resetTime;

    [Header("Changing the scatter at certain player states")]
    [SerializeField] private float standoffScatterCoefficient;
    [SerializeField] private float walkingScatterCoefficient;
    [SerializeField] private float runningScatterCoefficient;
    [SerializeField] private float flightScatterCoefficient;
    [SerializeField] private float crouchingScatterCoefficient;
    
    
}
