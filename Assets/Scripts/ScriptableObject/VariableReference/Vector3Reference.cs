using UnityEngine;
using System;

[Serializable]
public class Vector3Reference : VariableReference<Vector3, Vector3Variable>
{
    public override string ToString()
    {
        return reference.Value.ToString();
    }
}