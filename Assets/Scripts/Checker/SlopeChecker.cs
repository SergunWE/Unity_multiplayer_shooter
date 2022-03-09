using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeChecker : Checker, ITrackingGroundChecker
{
    [SerializeField] private float maxSlopeAngle;
    [SerializeField] private float surfaceDetectionDistance;
    [SerializeField] private LayerMask groundMask;
    private RaycastHit _slopeHit;
    private bool _isGrounded;

    private void Update()
    {
        UpdateState();
    }

    protected override bool Check()
    {
        if (!_isGrounded) return false;
        if (Physics.Raycast(transform.position, Vector3.down, out _slopeHit,
            surfaceDetectionDistance, groundMask))
        {
            float angle = Vector3.Angle(Vector3.up, _slopeHit.normal);
            //Debug.Log(angle);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }
    
    public Vector3 GetSlopeMoveDirection(Vector3 moveDirection)
    {
        return Vector3.ProjectOnPlane(moveDirection, _slopeHit.normal).normalized;
    }
    
    public void OnPlayerGround()
    {
        _isGrounded = true;
    }

    public void OnPlayerAir()
    {
        _isGrounded = false;
    }
}