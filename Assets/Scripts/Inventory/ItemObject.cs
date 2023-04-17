using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Inventory/Item")]
public class ItemObject : ScriptableObject
{
    public string itemName;
    [TextArea()]
    public string itemDescription;
    public Sprite itemIcon;
    
    public bool stacks;

}
