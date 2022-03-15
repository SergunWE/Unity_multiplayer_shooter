using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueDisplay : MonoBehaviour
{
    [SerializeField] protected Text label;
    
    public void RefreshDisplay<T>(T value)
    {
        label.text = value.ToString();
    }
}
