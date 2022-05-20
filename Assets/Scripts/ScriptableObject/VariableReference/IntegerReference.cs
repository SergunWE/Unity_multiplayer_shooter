using System;
using UnityEngine;

[Serializable]
public class IntegerReference : VariableReference<int, IntegerVariable>
{
    public IntegerReference() : base()
    {
    }

    public IntegerReference(int value) : base(value)
    {
    }
}