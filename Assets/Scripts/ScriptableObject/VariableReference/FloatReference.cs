using System;
using UnityEngine;

[Serializable]
public class FloatReference : VariableReference<float, FloatVariable>
{
    public FloatReference() : base()
    {
    }

    public FloatReference(float value) : base(value)
    {
    }
}