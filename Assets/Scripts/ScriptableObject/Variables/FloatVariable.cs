using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Variable/Float")]
public class FloatVariable : Variable<float>
{
    public void SetValue(InputAction.CallbackContext context)
    {
        {
            float newValue = context.ReadValue<float>();
            if (IsValueEqual(newValue)) return;
            value = newValue;
            OnValueChange();
        }
    }
    protected override bool IsValueEqual(float newValue)
    {
        return value == newValue;
    }
}