using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Delays")]
public class WeaponDelays : ScriptableObject
{
    [SerializeField] private float pulling;
    [SerializeField] private float shoot;
    [SerializeField] private float reload;

    public float Pulling => pulling;
    public float Shoot => shoot;
    public float Reload => reload;
}
