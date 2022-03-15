using System;
using System.Collections;
using UnityEngine;

public class ChangingScaleCrouch : MonoBehaviour, ITrackingCrouch
{
    [SerializeField] private float multiplierCrouch;

    private Vector3 _startScale;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        _startScale = _transform.localScale;
    }

    #region GameEvent

    public void OnPlayerCrouches()
    {
        // StopAllCoroutines();
        // StartCoroutine(ChangeScale(new Vector3(_startScale.x, 
        //     _startScale.y * multiplierCrouch, _startScale.z), 0.2f));
        _transform.localScale = new Vector3(_startScale.x, multiplierCrouch * _startScale.y , _startScale.z);
    }

    public void OnPlayerStandUp()
    {
        // StopAllCoroutines();
        // StartCoroutine(ChangeScale(_startScale, 0.2f));
        _transform.localScale = _startScale;
    }

    #endregion
}