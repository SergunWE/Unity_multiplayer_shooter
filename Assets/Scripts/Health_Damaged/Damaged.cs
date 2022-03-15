using UnityEngine;

public class Damaged : MonoBehaviour, IDamageable
{
    [SerializeField] protected float damageMultiplier = 1;
    [SerializeField] protected Health health;

    public virtual void TakeDamage(int damage)
    {
        int actualDamage = (int)(damage * damageMultiplier);
        health.RecordDamage(actualDamage);
    }
}
