using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueDisplay<T> : MonoBehaviour
{
    [SerializeField] protected T value;
    [SerializeField] protected Text label;

    public virtual void RefreshDisplay()
    {
        RefreshDisplay(value);
    }

    public void RefreshDisplay(T newValue)
    {
        label.text = newValue.ToString();
    }
}
