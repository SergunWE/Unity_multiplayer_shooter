using UnityEngine;

public abstract class Checker : MonoBehaviour
{
    [SerializeField] protected GameEvent positiveStateEvent;
    [SerializeField] protected GameEvent negativeStateEvent;

    private bool _lastStateCheck;

    protected abstract bool Check();

    protected void UpdateState()
    {
        if (_lastStateCheck == Check()) return;
        _lastStateCheck = !_lastStateCheck;
        if (_lastStateCheck)
        {
            positiveStateEvent.Raise();
        }
        else
        {
            negativeStateEvent.Raise();
        }
    }
}