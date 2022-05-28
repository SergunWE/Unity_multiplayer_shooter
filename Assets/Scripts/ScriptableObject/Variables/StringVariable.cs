using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Variable/String")]
public class StringVariable : Variable<string>
{
    protected override bool IsValueEqual(string newValue)
    {
        return value == newValue;
    }
}