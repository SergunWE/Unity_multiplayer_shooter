using System;
using UnityEngine;

[Serializable]
public class Variable<T> : Constant<T>
{
    [SerializeField] private GameEvent valueChangeEvent;

    public void SetValue(T newValue)
    {
        value = newValue;
        OnValueChange();
    }

    public void SetValue(Variable<T> newValue)
    {
        value = newValue.value;
        OnValueChange();
    }

    private void OnValueChange()
    {
        if (valueChangeEvent != null)
        {
            valueChangeEvent.Raise();
        }
    }
}