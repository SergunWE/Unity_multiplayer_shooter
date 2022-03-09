using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerTracking : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    
    void Update()
    {
        transform.position = cameraPosition.position;
    }

    public void SetCameraPosition(Transform cam)
    {
        cameraPosition = cam;
    }
}
