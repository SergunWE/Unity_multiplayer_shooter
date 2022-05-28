using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Variable/Vector3")]
public class Vector3Variable : Variable<Vector3>
{
    public void SetValue(InputAction.CallbackContext context)
    {
        {
            var newValue = context.ReadValue<Vector3>();
            if (IsValueEqual(newValue)) return;
            value = newValue;
            OnValueChange();
        }
    }
    protected override bool IsValueEqual(Vector3 newValue)
    {
        return value == newValue;
    }
}