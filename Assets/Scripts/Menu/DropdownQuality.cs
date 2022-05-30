using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Dropdown))]
public class DropdownQuality : MonoBehaviour
{
    private TMP_Dropdown _dropdown;
    private void Awake()
    {
        _dropdown = GetComponent<TMP_Dropdown>();
    }

    public void SetValue(int index)
    {
        GraphicSettings.SetQuality(index);
    }

    private void RefreshValues()
    {
        _dropdown.value = GraphicSettings.GetCurrentQualityIndex();
    }

    private void OnEnable()
    {
        RefreshValues();
    }
}
