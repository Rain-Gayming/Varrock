using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemObject item;
    public int amount;

    public Item(ItemObject i, int a)
    {
        item = i;
        amount = a;
    }
}
