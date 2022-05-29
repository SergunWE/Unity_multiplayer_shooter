using System;
using UnityEngine;
using WebSocketSharp;

public class HealthDisplay : ValueDisplay<IntegerReference>
{
    [SerializeField] private string stringBeforeValue = "";

    private void Start()
    {
        RefreshDisplay();
    }

    public override void RefreshDisplay(string newFirstValue)
    {
        base.RefreshDisplay(newFirstValue);
        if (stringBeforeValue.IsNullOrEmpty()) return;
        label.text = stringBeforeValue + label.text;
    }
}