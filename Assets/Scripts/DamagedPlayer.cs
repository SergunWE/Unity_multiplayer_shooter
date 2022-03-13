using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedPlayer : Damaged
{
    
    
    public override void TakeDamage(float damage)
    {
        float actualDamage = damage * damageMultiplier;
        health.RecordDamage(actualDamage);
    }
}
