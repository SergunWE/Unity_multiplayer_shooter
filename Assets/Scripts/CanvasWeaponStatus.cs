using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasWeaponStatus : MonoBehaviour
{
    [SerializeField] private Text label;

    public void SetLabel(string s)
    {
        label.text = s;
    }
}
