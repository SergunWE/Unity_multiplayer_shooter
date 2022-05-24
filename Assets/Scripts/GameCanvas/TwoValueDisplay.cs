using System.Text;
using UnityEngine;

public class TwoValueDisplay<T> : ValueDisplay<T>
{
    [SerializeField] protected T secondValue;
    [SerializeField] protected char valueBaffle = '/';

    private StringBuilder _stringBuilder;
    
    protected virtual void Awake()
    {
        _stringBuilder = new StringBuilder();
    }

    public override void RefreshDisplay()
    {
        RefreshDisplay(value, secondValue);
    }

    public void RefreshDisplay<TV>(TV newFirstValue, TV newSecondValue)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(newFirstValue);
        _stringBuilder.Append(valueBaffle);
        _stringBuilder.Append(newSecondValue);
        label.text = _stringBuilder.ToString();
    }
}
