using System;
using UnityEngine;

[Serializable]
public abstract class Health<T, TM> : MonoBehaviour
{
    [SerializeField] protected T value;
    [SerializeField] protected TM maxValue;

    protected abstract void Start();
    public abstract void RecordDamage(int damage);
    public abstract void CheckValue();
    protected abstract void Death();
}