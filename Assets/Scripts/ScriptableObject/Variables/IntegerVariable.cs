using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Variable/Integer")]
public class IntegerVariable : Variable<int>
{
    protected override bool IsValueEqual(int newValue)
    {
        return value == newValue;
    }
}