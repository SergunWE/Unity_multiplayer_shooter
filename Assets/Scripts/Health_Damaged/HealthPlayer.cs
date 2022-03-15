using UnityEngine;

public class HealthPlayer : HealthPhoton
{
    [SerializeField] private GameEvent onPlayerDied;
    
    protected override void Death()
    {
        onPlayerDied.Raise();
    }
}
