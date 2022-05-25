using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/New Event")]
public class GameEvent : UnityEngine.ScriptableObject
{
    private readonly List<GameEventListener> _listeners =
        new List<GameEventListener>();

    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].OnEventRaised();
    }

    public void RegisterListener(GameEventListener listener)
    {
        _listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        _listeners.Remove(listener);
    }
}