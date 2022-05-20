using UnityEngine;

[CreateAssetMenu(menuName = "Variable/Float")]
public class FloatVariable : StackableVariable<float>
{
    public override void ApplyChange(float amount)
    {
        base.ApplyChange(amount);
        value += amount;
    }

    public override void ApplyChange(Variable<float> amount)
    {
        base.ApplyChange(amount);
        value += amount.Value;
    }
}