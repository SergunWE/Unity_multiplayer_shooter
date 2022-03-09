using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Weapon Delays")]
public class WeaponDelays : ScriptableObject
{
    [SerializeField] private float drawTime;
    [SerializeField] private float rateFire;
    [SerializeField] private float reloadTime;

    public float DrawTime => drawTime;
    public float RateFire => rateFire;
    public float ReloadTime => reloadTime;
}
