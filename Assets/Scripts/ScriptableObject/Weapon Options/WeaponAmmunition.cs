using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Ammunition")]
public class WeaponAmmunition : ScriptableObject
{
    [SerializeField] private int clip;
    [SerializeField] private int total;

    public int Clip => clip;
    public int Total => total;
}
