using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour, ITrackingGroundChecker
{
    [SerializeField] private float jumpForce;
    [SerializeField] private GameEvent onPlayerJumped;

    private bool _isGrounded = false;

    private Rigidbody _rigidbody;

    private Transform _transform;
    private Vector3 _velocity;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponentInParent<Rigidbody>();
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _velocity = _rigidbody.velocity;
            _rigidbody.velocity.Set(_velocity.x, 0f, _velocity.z);
            onPlayerJumped.Raise();
            _rigidbody.AddForce(jumpForce * _transform.up, ForceMode.VelocityChange);
        }
    }

    #region InputEvent

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Jump();
    }

    #endregion


    #region GameEvent

    public void OnPlayerGround()
    {
        _isGrounded = true;
    }

    public void OnPlayerAir()
    {
        _isGrounded = false;
    }

    #endregion
}