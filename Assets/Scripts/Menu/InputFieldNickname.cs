using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_InputField))]
public class InputFieldNickname : MonoBehaviour
{
    private TMP_InputField _field;

    private void Awake()
    {
        _field = GetComponent<TMP_InputField>();
    }

    public void SaveValue()
    {
        string nick = _field.text.Replace(" ", "");
        _field.text = nick;
        if (!string.IsNullOrEmpty(nick))
        {
            PlayerSettings.SetNickname(nick);
        }
    }

    private void RefreshValue()
    {
        _field.text = PlayerSettings.GetNickname();
    }

    private void OnEnable()
    {
        RefreshValue();
    }
}
