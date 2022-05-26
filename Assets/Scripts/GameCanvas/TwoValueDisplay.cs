using System.Text;
using UnityEngine;

public sealed class TwoValueDisplay<T> : ValueDisplay<T>
{
    [SerializeField] private T secondValue;
    [SerializeField] private char valueBaffle = '/';

    private StringBuilder _stringBuilder;

    private void Awake()
    {
        _stringBuilder = new StringBuilder();
    }

    public override void RefreshDisplay()
    {
        RefreshDisplay(value, secondValue);
    }

    public void RefreshDisplay(T newFirstValue, T newSecondValue)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(newFirstValue);
        _stringBuilder.Append(valueBaffle);
        _stringBuilder.Append(newSecondValue);
        label.text = _stringBuilder.ToString();
    }
}
