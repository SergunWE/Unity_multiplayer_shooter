using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ItemInfo itemInfo;
    [SerializeField] protected GameObject itemModel;

    public abstract void Use();

    public abstract void ShowItem();

    public abstract void HideItem();
}
