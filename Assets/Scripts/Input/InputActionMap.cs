using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionMap : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _playerInput.actions.FindActionMap("Player").Enable();
        _playerInput.actions.FindActionMap("Weapon").Enable();
    }
}
