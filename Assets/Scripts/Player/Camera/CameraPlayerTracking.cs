using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerTracking : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    
    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
