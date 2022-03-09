using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Animation")]
public class WeaponAnimations : ScriptableObject
{
    [SerializeField] private Animation pulling;
    [SerializeField] private Animation inactivity;
    [SerializeField] private Animation shoot;
    [SerializeField] private Animation reload;

    public Animation Pulling => pulling;
    public Animation Inactivity => inactivity;
    public Animation Shoot => shoot;
    public Animation Reload => reload;
}
