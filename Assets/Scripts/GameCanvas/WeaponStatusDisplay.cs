using UnityEngine;
using UnityEngine.UI;

public class WeaponStatusDisplay : MonoBehaviour
{
    [SerializeField] private Text weaponStatusLabel;
    
    public void RefreshDisplay(string status)
    {
        weaponStatusLabel.text = status;
    }
}
