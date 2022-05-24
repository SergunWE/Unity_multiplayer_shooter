using UnityEngine;
using UnityEngine.UI;

public class ValueDisplay<T> : MonoBehaviour
{
    [SerializeField] protected T value;
    [SerializeField] protected Text label;

    public virtual void RefreshDisplay()
    {
        RefreshDisplay(value.ToString());
    }

    public virtual void RefreshDisplay(string newValue)
    {
        label.text = newValue;
    }
}
