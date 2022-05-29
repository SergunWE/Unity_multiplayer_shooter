using System;
using System.Globalization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class SensitivitySettingField : MonoBehaviour
{
    [SerializeField] private string playerPrefsName;

    private TMP_InputField _field;
    private float _value;

    private void Awake()
    {
        _field = GetComponent<TMP_InputField>();
        _value = GetValue();
    }

    private void OnEnable()
    {
        _value = GetValue();
        SetValueField();
    }

    public void ChangeValue(string str)
    {
        try
        {
            float prevValue = _value;
            _value = float.Parse(str);
            if (_value <= 0)
            {
                _value = prevValue;
                SetValueField();
                return;
            }
            PlayerPrefs.SetFloat(playerPrefsName, _value);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            throw;
        }
        
    }

    private float GetValue()
    {
        return PlayerPrefs.GetFloat(playerPrefsName, 1.0f);
    }

    private void SetValueField()
    {
        _field.text = _value.ToString(CultureInfo.CurrentCulture);
    }
}
