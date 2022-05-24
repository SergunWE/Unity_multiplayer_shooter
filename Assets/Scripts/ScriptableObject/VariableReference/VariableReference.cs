using System;
using UnityEngine;

[Serializable]
public abstract class VariableReference<T, TV>
{
    [SerializeField] protected TV reference;
    
    protected T Value()
    {
        if (reference is Variable<T> variable)
        {
            return variable.Value;
        }

        throw new ArgumentNullException();
    }

    public static implicit operator T(VariableReference<T, TV> reference)
    {
        return reference.Value();
    }

    public abstract override string ToString();
}