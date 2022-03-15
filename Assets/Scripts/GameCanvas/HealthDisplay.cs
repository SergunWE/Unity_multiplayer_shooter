using System;
using System.Collections;
using UnityEngine;
using WebSocketSharp;

public class HealthDisplay : TwoValueDisplay
{
    [SerializeField] private Color colorDamage;

    [SerializeField] private float colorRetentionTime;
    [SerializeField] private float colorChangeTime;

    [SerializeField] private string stringBeforeValue = "";


    private Color _originalColor;

    protected override void Awake()
    {
        base.Awake();
        _originalColor = label.color;
    }

    public override void RefreshDisplay<T>(T firstValue, T secondValue)
    {
        base.RefreshDisplay(firstValue, secondValue);
        if (!stringBeforeValue.IsNullOrEmpty())
        {
            label.text = stringBeforeValue + label.text;
        }
    }

    public void RefreshDisplayWithColor<T>(T firstValue, T secondValue, ValueColor valueColor)
    {
        RefreshDisplay(firstValue, secondValue);
        StopAllCoroutines();
        StartCoroutine(ChangeColor(GetValueColor(valueColor)));
    }

    private Color GetValueColor(ValueColor valueColor)
    {
        switch ((int)valueColor)
        {
            case 0:
                return colorDamage;
            case 1:
                return Color.yellow;
            default:
                return Color.clear;
        }
    }

    private IEnumerator ChangeColor(Color color)
    {
        label.color = color;
        yield return new WaitForSeconds(colorRetentionTime);
        float t = 0;
        while (t < 1)
        {
            label.color = Color.Lerp(label.color, _originalColor, t);
            t += Time.deltaTime / colorChangeTime;
            yield return null;
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

}

public enum ValueColor
{
    ColorDamage,
    ColorHeal
}