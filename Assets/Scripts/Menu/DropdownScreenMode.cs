using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class DropdownScreenMode : MonoBehaviour
{
    [SerializeField] private string fullScreenKey;
    private TMP_Dropdown _dropdown;
    
    private void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
    }

    private void RefreshValue()
    {
        _dropdown.value = PlayerPrefs.GetInt(fullScreenKey, 1);
    }

    private void OnEnable()
    {
        RefreshValue();
    }
}
