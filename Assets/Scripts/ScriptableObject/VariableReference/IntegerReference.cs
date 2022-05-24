using System;
using UnityEngine;

[Serializable]
public class IntegerReference : VariableReference<int, IntegerVariable>
{
    public override string ToString()
    {
        return reference.Value.ToString();
    }
}