using UnityEngine;

public class HealthShield : HealthPhoton
{
    [SerializeField] private GameEvent onShieldDestroyed;
    protected override void Death()
    { 
        onShieldDestroyed.Raise();
    }
}
