using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] private float smooth;
    [SerializeField] private float xSwayMultiplier;
    [SerializeField] private float ySwayMultiplier;
    [SerializeField] private float angleLimit;

    private Quaternion _xRotation;
    private Quaternion _yRotation;

    private Quaternion _targetRotation;
    
    private Vector2 _inputAxis;

    private float _yAngle;
    private float _xAngle;

    private void Update()
    {
        _yAngle = Mathf.Clamp(_inputAxis.y * xSwayMultiplier, -angleLimit, angleLimit);
        _xAngle = Mathf.Clamp(_inputAxis.x * ySwayMultiplier, -angleLimit, angleLimit);

        _xRotation = Quaternion.AngleAxis(_yAngle, Vector3.right);
        _yRotation = Quaternion.AngleAxis(-_xAngle, Vector3.up);

        _targetRotation = _xRotation * _yRotation;

        transform.localRotation = Quaternion.Lerp
            (transform.localRotation, _targetRotation, smooth * Time.deltaTime);
    }
    
    public void OnView(InputAction.CallbackContext context)
    {
        //if (!context.performed) return;
        _inputAxis = context.ReadValue<Vector2>();
    }
}
