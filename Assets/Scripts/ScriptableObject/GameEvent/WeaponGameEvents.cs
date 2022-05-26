using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/New WeaponGameEvents")]
public class WeaponGameEvents : ScriptableObject
{
    [SerializeField] private GameEvent onWeaponPulling;
    [SerializeField] private GameEvent onWeaponReady;
    [SerializeField] private GameEvent onWeaponUse;
    [SerializeField] private GameEvent onWeaponAlternateUse;
    [SerializeField] private GameEvent onWeaponReload;
    [SerializeField] private GameEvent onWeaponClipReplaced;

    public void OnWeaponPulling() => onWeaponPulling.Raise();
    public void OnWeaponReady() => onWeaponReady.Raise();
    public void OnWeaponUse() => onWeaponUse.Raise();
    public void OnWeaponAlternateUse() => onWeaponAlternateUse.Raise();
    public void OnWeaponReload() => onWeaponReload.Raise();
    public void OnWeaponClipReplaced() => onWeaponClipReplaced.Raise();
}
