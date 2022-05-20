using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Integer")]
[Serializable]
public class IntegerVariable : StackableVariable<int>
{
    public override void ApplyChange(int amount)
    {
        base.ApplyChange(amount);
        value += amount;
    }

    public override void ApplyChange(Variable<int> amount)
    {
        base.ApplyChange(amount);
        value += amount.Value;
    }
}