using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(menuName = "Loot/CraftingRecipe",fileName = "CR_")]
public class CraftingRecipe : ScriptableObject
{
    public List<Item> itemsRequired;
    public Item returnItem;
}
