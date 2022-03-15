using UnityEngine;

public class Shield : MonoBehaviour
{
    public void DestroyShield()
    {
        Destroy(GetComponent<ChangingScaleCrouch>());
        transform.localScale = Vector3.zero;
    }
}
