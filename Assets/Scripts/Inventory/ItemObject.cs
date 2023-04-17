using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Loot/Item", fileName = "Item_")]
public class ItemObject : ScriptableObject
{
    public EItemType itemType;
    public string itemName;
    [TextArea()]
    public string itemDescription;
    public Sprite itemIcon;
    
    public bool stacks;

}
