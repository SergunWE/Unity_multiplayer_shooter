using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraView : MonoBehaviour
{
    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private Transform cameraPosition;

    private float _xRotation = 0f;
    private float _yRotation = 0f;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void View(Vector2 inputAxis)
    {
        _yRotation += inputAxis.x * xSensitivity;

        _xRotation -= inputAxis.y * ySensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -89f, 89f);

        if(cameraHolder == null) return;
        cameraHolder.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
    }
    
    
    public void OnView(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        View(context.ReadValue<Vector2>());
    }

    private void OnDestroy()
    {
        //Debug.Log("Destroy camera");
        Destroy(cameraHolder.GetComponentInChildren<Camera>().gameObject);
    }
}
