using System;
using System.Globalization;

[Serializable]
public class FloatReference : VariableReference<float, FloatVariable>
{
    public override string ToString()
    {
        return reference.Value.ToString(CultureInfo.InvariantCulture);
    }
}