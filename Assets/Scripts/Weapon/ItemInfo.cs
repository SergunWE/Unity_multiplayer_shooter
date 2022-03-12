using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo : ScriptableObject
{
    [SerializeField] private string itemName;

    public string ItemName => itemName;
}
