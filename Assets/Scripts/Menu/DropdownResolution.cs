using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class DropdownResolution : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    private void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
    }

    public void SetValue(int index)
    {
        GraphicSettings.SetResolution(index);
    }

    private void RefreshValues()
    {
        _dropdown.ClearOptions();
        _dropdown.AddOptions(GraphicSettings.ResolutionNames);

        int index = GraphicSettings.GetCurrentResolutionIndex();
        if (index >= 0)
        {
            _dropdown.value = GraphicSettings.GetCurrentResolutionIndex();
        }
    }

    private void OnEnable()
    {
        RefreshValues();
    }
}