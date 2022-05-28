using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Variable/Vector2")]
public class Vector2Variable : Variable<Vector2>
{
    public void SetValue(InputAction.CallbackContext context)
    {
        {
            var newValue = context.ReadValue<Vector2>();
            if (IsValueEqual(newValue)) return;
            value = newValue;
            OnValueChange();
        }
    }

    protected override bool IsValueEqual(Vector2 newValue)
    {
        return value == newValue;
    }
}