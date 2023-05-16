using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Item", fileName = "Item_")]
public class ItemObject : ScriptableObject
{
    
    [BoxGroup("Basic Info")]
    public EItemType itemType;

    [BoxGroup("Basic Info")]
    public string itemName;
    [BoxGroup("Basic Info")]
    [TextArea(5, 10)]
    public string itemInfo = "<color=yellow>Type: Boots </color>" + "\n" +  "\n" + "<color=green>Buy Price: 50</color>"  + "\n" +  "<color=red>Sell Price: 35</color>";
    
    [BoxGroup("Basic Info")]
    [TextArea(10, 15)]
    public string itemDescription;

    [HorizontalGroup("Inventory Display", 75)]
    [PreviewField(75)]
    [HideLabel]
    public Sprite itemIcon;

    [VerticalGroup("Inventory Display/Bools")]
    public bool stacks;
    
    [BoxGroup("Shop Info")]
    public int sellPrice;

    [BoxGroup("Shop Info")]
    public int buyPrice;

    [Button("Set Info")]
    public void ResetDescription()
    {
        int length = name.Length;
        int lengthResult = length -= 5;
        string result = name.Substring(5, lengthResult);
        itemName = result;

        sellPrice = (buyPrice / 2);

        itemInfo = "<color=yellow>Type: " + itemType.ToString() + "</color>" + "\n" +  "\n" + "<color=green>Buy Price: " + buyPrice.ToString() + "</color>"  + "\n" +  "<color=red>Sell Price: " + sellPrice.ToString() + "</color>";
    }
    public List<ItemInteraction> itemInteractions;
}

[System.Serializable]
public class ItemInteraction
{
    public ItemObject interactWith;
    public ItemObject itemResult;    
}