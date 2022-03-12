using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] private float smooth;
    [SerializeField] private float xSwayMultiplier;
    [SerializeField] private float ySwayMultiplier;

    private Quaternion _xRotation;
    private Quaternion _yRotation;

    private Quaternion _targetRotation;
    
    private Vector2 _inputAxis;

    private void Update()
    {
        _xRotation = Quaternion.AngleAxis(_inputAxis.y * xSwayMultiplier, Vector3.right);
        _yRotation = Quaternion.AngleAxis(-_inputAxis.x * ySwayMultiplier, Vector3.up);

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
