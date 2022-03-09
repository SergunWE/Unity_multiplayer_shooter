using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrag : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float groundDrag;
    private bool _isGrounded;
    
    private void Awake()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
    }

    public void OnPlayerOnGround()
    {
        _rigidbody.drag = groundDrag;
    }

    public void OnPlayerOnAir()
    {
        _rigidbody.drag = 0;
    }
}
