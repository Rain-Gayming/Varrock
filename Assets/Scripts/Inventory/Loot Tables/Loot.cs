using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Loot
{
    public Item item;
    public int minimumAmount;
    public int maximumAmount;
    [Range(0, 100)]
    public int weight;
}
