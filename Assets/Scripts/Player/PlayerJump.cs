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

    private void Awake()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            var velocity = _rigidbody.velocity;
            velocity = new Vector3(velocity.x, 0f, velocity.z);
            _rigidbody.velocity = velocity;
            onPlayerJumped.Raise();
            _rigidbody.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
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