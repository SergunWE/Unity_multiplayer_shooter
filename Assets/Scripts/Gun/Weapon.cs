using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : Item
{
    public abstract override void Use();
    
    public abstract override void ShowItem();
    public abstract override void HideItem();
}
