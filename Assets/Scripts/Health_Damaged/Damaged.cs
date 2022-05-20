using UnityEngine;

public abstract class Damaged : MonoBehaviour, IDamageable
{
    [SerializeField] protected float damageMultiplier = 1;
    protected int ActualDamage;

    public virtual void TakeDamage(int damage)
    {
        ActualDamage = (int)(damage * damageMultiplier);
    }
}
