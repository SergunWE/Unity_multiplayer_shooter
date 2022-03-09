using System.Collections;
using UnityEngine;

public class ChangingScaleCrouch : MonoBehaviour, ITrackingCrouch
{
    [SerializeField] private float multiplierCrouch;

    private Vector3 _startScale;
    
    private void Start()
    {
        _startScale = transform.localScale;
    }
    
    private IEnumerator ChangeScale(Vector3 finishHeight, float animationDuration)
    {
        Vector3 startHeight = transform.localScale;

        float t = 0;

        while (t < 1)
        {
            transform.localScale = Vector3.Lerp(startHeight, finishHeight, t);
            t += Time.deltaTime / animationDuration;
            yield return null;
        }

        transform.localScale = finishHeight;
    }

    public void OnPlayerCrouches()
    {
        // StopAllCoroutines();
        // StartCoroutine(ChangeScale(new Vector3(_startScale.x, 
        //     _startScale.y * multiplierCrouch, _startScale.z), 0.2f));
        transform.localScale = new Vector3(_startScale.x, _startScale.y * multiplierCrouch, _startScale.z);
    }

    public void OnPlayerStandUp()
    {
        // StopAllCoroutines();
        // StartCoroutine(ChangeScale(_startScale, 0.2f));
        transform.localScale = _startScale;
    }
}