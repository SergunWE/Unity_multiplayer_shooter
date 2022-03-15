using Photon.Pun;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxValue;
    [SerializeField] private float _value;

    private void Start()
    {
        _value = maxValue;
    }
    
    public virtual void RecordDamage(float damage)
    {
        _value -= damage;
        CheckValue();
    }

    private void CheckValue()
    {
        Debug.Log("check value" + _value);
        if (_value <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        Debug.Log("Death");
    }
}
