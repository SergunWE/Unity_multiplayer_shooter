using System;
using UnityEngine;

[Serializable]
public abstract class StackableVariable<T> : Variable<T>
{
    [SerializeField] private GameEvent valuePositiveChangeEvent;
    [SerializeField] private GameEvent valueNegativeChangeEvent;

    public virtual void ApplyChange(T amount)
    {
        IdentifyNumericType(amount);
    }

    public virtual void ApplyChange(Variable<T> amount)
    {
        IdentifyNumericType(amount.Value);
    }

    private void ValueChangeSign(float definedValue)
    {
        if (Math.Sign(definedValue) < 0 && valuePositiveChangeEvent != null)
        {
            valuePositiveChangeEvent.Raise();
            return;
        }

        if (valueNegativeChangeEvent != null)
        {
            valueNegativeChangeEvent.Raise();
        }
        
    }

    private void IdentifyNumericType(T obj)
    {
        switch (obj)
        {
            case int intType:
                ValueChangeSign(intType);
                break;
            case float floatType:
                ValueChangeSign(floatType);
                break;
        }
    }
    
}