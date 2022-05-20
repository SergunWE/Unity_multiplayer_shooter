using UnityEngine;
using System;

[Serializable]
public class Vector3Reference : VariableReference<Vector3, Vector3Variable>
{
    public Vector3Reference() : base()
    {
    }

    public Vector3Reference(Vector3 value) : base(value)
    {
    }
}