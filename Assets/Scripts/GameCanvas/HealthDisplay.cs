using UnityEngine;
using WebSocketSharp;

public class HealthDisplay : TwoValueDisplay<IntegerReference>
{
    [SerializeField] private string stringBeforeValue = "";

    public override void RefreshDisplay()
    {
        RefreshDisplay<int>(value, secondValue);
    }

    public override void RefreshDisplay<TV>(TV newFirstValue, TV newSecondValue)
    {
        base.RefreshDisplay(newFirstValue, newSecondValue);
        if (!stringBeforeValue.IsNullOrEmpty())
        {
            label.text = stringBeforeValue + label.text;
        }
    }
}