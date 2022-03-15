using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas Instance;

    [SerializeField] private AmmunitionDisplay ammunitionDisplay;
    [SerializeField] private WeaponNameDisplay weaponNameDisplay;
    [SerializeField] private WeaponStatusDisplay weaponStatusDisplay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateAmmunition(int clip, int total)
    {
        ammunitionDisplay.RefreshDisplay(clip, total);
    }

    public void UpdateWeaponName(string weaponName)
    {
        weaponNameDisplay.RefreshDisplay(weaponName);
    }
    
    public void UpdateWeaponStatus(string status)
    {
        weaponStatusDisplay.RefreshDisplay(status);
    }
}
