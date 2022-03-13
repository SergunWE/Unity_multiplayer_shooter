using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxValue;
    private float _value;

    private void Awake()
    {
        _value = maxValue;
    }

    public void RecordDamage(float damage)
    {
        Debug.Log(damage);
        _value -= damage;
        CheckValue();
    }

    private void CheckValue()
    {
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
