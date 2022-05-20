using UnityEngine;
using System;

[Serializable]
public class Vector2Reference : VariableReference<Vector2, Vector2Variable>
{
    public Vector2Reference() : base()
    {
    }

    public Vector2Reference(Vector2 value) : base(value)
    {
    }
}