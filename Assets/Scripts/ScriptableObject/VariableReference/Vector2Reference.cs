using UnityEngine;
using System;

[Serializable]
public class Vector2Reference : VariableReference<Vector2, Vector2Variable>
{
    public override string ToString()
    {
        return reference.Value.ToString();
    }
}