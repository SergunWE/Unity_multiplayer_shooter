using UnityEngine;

public class HealthObject : Health<int, int>
{
    protected override void Start()
    {
        value = maxValue;
    }

    public override void RecordDamage(int damage)
    {
        value -= damage;
        CheckValue();
    }

    public override void CheckValue()
    {
        if (value <= 0)
        {
            Death();
        }
    }

    protected override void Death()
    {
        Debug.Log("Death");
        Destroy(gameObject);
    }
}