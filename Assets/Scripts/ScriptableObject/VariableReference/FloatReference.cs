using System;
using System.Globalization;
using UnityEngine;

[Serializable]
public class FloatReference : VariableReference<float, FloatVariable>
{
    public override string ToString()
    {
        return reference.Value.ToString(CultureInfo.InvariantCulture);
    }
}