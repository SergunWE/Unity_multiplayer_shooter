using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TwoValueDisplay : ValueDisplay
{
    [SerializeField] private char valueBaffle = '/';

    private StringBuilder _stringBuilder;
    

    protected virtual void Awake()
    {
        _stringBuilder = new StringBuilder();
    }

    public virtual void RefreshDisplay<T>(T firstValue, T secondValue)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(firstValue);
        _stringBuilder.Append(valueBaffle);
        _stringBuilder.Append(secondValue);
        label.text = _stringBuilder.ToString();
    }
}
