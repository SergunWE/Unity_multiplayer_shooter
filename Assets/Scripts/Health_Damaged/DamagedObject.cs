using UnityEngine;

public class DamagedObject : Damaged
{
    [SerializeField] protected HealthObject health;

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        health.RecordDamage(ActualDamage);
    }
}