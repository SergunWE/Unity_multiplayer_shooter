using UnityEngine;

public class Damaged : MonoBehaviour, IDamageable
{
    [SerializeField] protected float damageMultiplier = 1;
    [SerializeField] protected Health health;

    public virtual void TakeDamage(float damage)
    {
        float actualDamage = damage * damageMultiplier;
        health.RecordDamage(actualDamage);
    }
}
