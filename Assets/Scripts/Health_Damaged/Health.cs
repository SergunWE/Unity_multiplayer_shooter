using Photon.Pun;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int maxValue;
    [SerializeField] protected int _value;

    protected virtual void Start()
    {
        _value = maxValue;
    }
    
    public virtual void RecordDamage(int damage)
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
