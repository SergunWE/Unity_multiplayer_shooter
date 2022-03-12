using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCrouch : MonoBehaviour
{
    [SerializeField] private float crouchRatio;
    [SerializeField] private CapsuleCollider playerCollider;
    [SerializeField] private Transform cameraPosition;

    [SerializeField] private LayerMask overheadMask;
    [SerializeField] private float heightCheckOverhead;

    [SerializeField] private GameEvent onPlayerCrouches;
    [SerializeField] private GameEvent onPlayerStandUp;

    private float _playerHeight;
    private float _cameraHeight;

    private void Start()
    {
        _playerHeight = playerCollider.height;
        _cameraHeight = cameraPosition.localPosition.y;
    }


    private IEnumerator ChangePosition(float finishPlayerHeight, Vector3 finishCameraPosition,
        GameEvent gameEvent, float animationDuration)
    {
        gameEvent.Raise();
        float startPlayerHeight = playerCollider.height;
        Vector3 startCameraPosition = cameraPosition.localPosition;

        float t = 0;

        while (t < 1)
        {
            playerCollider.height = Mathf.Lerp(startPlayerHeight, finishPlayerHeight, t);
            cameraPosition.localPosition = Vector3.Lerp(startCameraPosition, finishCameraPosition, t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        playerCollider.height = finishPlayerHeight;
        cameraPosition.localPosition = finishCameraPosition;
    }

    private IEnumerator CheckOverhead()
    {
        while (Physics.Raycast(transform.position, Vector3.up,
            heightCheckOverhead, overheadMask))
        {
            yield return null;
        }

        StopAllCoroutines();
        StartCoroutine(ChangePosition(_playerHeight,
            new Vector3(0f, _cameraHeight, 0f), onPlayerStandUp, 0.1f));
    }

    #region InputEvent

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("Crouch");
            StopAllCoroutines();
            StartCoroutine(ChangePosition(_playerHeight * crouchRatio,
                new Vector3(0f, _cameraHeight * crouchRatio, 0f), onPlayerCrouches,
                0.1f));
        }
        else
        {
            if (!context.canceled) return;
            StartCoroutine(CheckOverhead());
        }
    }

    #endregion
}