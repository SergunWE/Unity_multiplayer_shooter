using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Sounds")]
public class WeaponSounds : ScriptableObject
{
    [SerializeField] private AudioClip pulling;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioClip reload;

    public AudioClip Pulling => pulling;
    public AudioClip Shoot => shoot;
    public AudioClip Reload => reload;
}
