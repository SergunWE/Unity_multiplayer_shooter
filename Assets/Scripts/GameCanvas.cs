using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas Instance;

    [SerializeField] private Text ammunitionLabel;
    [SerializeField] private Text weaponNameLabel;
    [SerializeField] private Text weaponStatusLabel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateAmmunition(int clip, int total)
    {
        ammunitionLabel.text = clip + "/" + total;
    }

    public void UpdateWeaponName(string weaponName)
    {
        weaponNameLabel.text = weaponName;
    }
    
    public void UpdateWeaponStatus(string status)
    {
        weaponStatusLabel.text = status;
    }
}
