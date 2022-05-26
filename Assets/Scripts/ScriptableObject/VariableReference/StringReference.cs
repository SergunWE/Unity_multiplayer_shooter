using System;

[Serializable]
public class StringReference : VariableReference<string, StringVariable>
{
    public override string ToString()
    {
        return reference.Value;
    }
}