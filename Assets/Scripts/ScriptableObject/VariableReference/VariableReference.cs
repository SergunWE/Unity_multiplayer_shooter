using System;
using UnityEngine;

[Serializable]
public class VariableReference<T, TV>
{
    [SerializeField] private TV reference;
    [SerializeField] private T constantValue;
    [SerializeField] private bool useConstant = true;

    protected VariableReference()
    {
    }

    protected VariableReference(T value)
    {
        useConstant = true;
        constantValue = value;
    }

    protected T Value()
    {
        if (reference is Variable<T> variable)
        {
            return useConstant ? constantValue : variable.Value;
        }

        throw new ArgumentNullException();
    }

    public static implicit operator T(VariableReference<T, TV> reference)
    {
        return reference.Value();
    }
}