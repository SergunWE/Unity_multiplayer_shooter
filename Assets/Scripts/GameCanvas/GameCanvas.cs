using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas Instance;

    [SerializeField] private AmmunitionDisplay ammunitionDisplay;
    [SerializeField] private WeaponNameDisplay weaponNameDisplay;
    [SerializeField] private WeaponStatusDisplay weaponStatusDisplay;
    [SerializeField] private HealthPlayerDisplay healthPlayerDisplay;
    [SerializeField] private HealthShieldDisplay healthShieldDisplay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateAmmunition(int clip, int total)
    {
        if (ammunitionDisplay == null) return;
        ammunitionDisplay.RefreshDisplay(clip, total);
    }

    public void UpdateWeaponName(string weaponName)
    {
        if (weaponNameDisplay == null) return;
        weaponNameDisplay.RefreshDisplay(weaponName);
    }

    public void UpdateWeaponStatus(string status)
    {
        if (weaponStatusDisplay == null) return;
        weaponStatusDisplay.RefreshDisplay<string>(status);
    }

    public void UpdatePlayerHealth(int value, int maxValue)
    {
        if (healthPlayerDisplay == null) return;
        healthPlayerDisplay.RefreshDisplay(value, maxValue);
    }
    
    public void UpdatePlayerHealth(int value, int maxValue, ValueColor color)
    {
        if (healthPlayerDisplay == null) return;
        healthPlayerDisplay.RefreshDisplayWithColor(value, maxValue, color);
    }
    
    public void UpdateShieldHealth(int value, int maxValue)
    {
        if (healthShieldDisplay == null) return;
        healthShieldDisplay.RefreshDisplay(value, maxValue);
    }
    
    public void UpdateShieldHealth(int value, int maxValue, ValueColor color)
    {
        if (healthShieldDisplay == null) return;
        healthShieldDisplay.RefreshDisplayWithColor(value, maxValue, color);
    }
}