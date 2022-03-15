using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponNameDisplay : MonoBehaviour
{
    [SerializeField] private Text weaponNameLabel;

    public void RefreshDisplay(string weaponName)
    {
        weaponNameLabel.text = weaponName;
    }
}
