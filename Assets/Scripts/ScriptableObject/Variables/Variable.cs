using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public abstract class Variable<T> : Constant<T>
{
    [SerializeField] private GameEvent valueChangeEvent;

    public void SetValue(T newValue)
    {
        if (IsValueEqual(newValue)) return;
        value = newValue;
        OnValueChange();
    }

    public void SetValue(Variable<T> newValue)
    {
        if (IsValueEqual(newValue)) return;
        value = newValue.value;
        OnValueChange();
    }

    protected abstract bool IsValueEqual(T newValue);

    protected void OnValueChange()
    {
        if (valueChangeEvent != null)
        {
            valueChangeEvent.Raise();
        }
    }
}