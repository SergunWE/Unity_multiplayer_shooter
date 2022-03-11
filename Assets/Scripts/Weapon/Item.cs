using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    //[SerializeField] private ItemInfo itemInfo;

    public abstract void Use();
    public abstract void AlternateUse();
}
