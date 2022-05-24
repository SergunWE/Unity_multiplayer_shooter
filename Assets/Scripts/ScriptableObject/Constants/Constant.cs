using System;
using UnityEngine;

public class Constant<T> : ScriptableObject
{
    [Multiline] [SerializeField] private string developerDescription;
    [SerializeField] protected T value;
    
    public T Value => value;
    
    public static implicit operator T(Constant<T> constant)
    {
        return constant.Value;
    }
}