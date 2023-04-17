using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class CraftingRecipeSlot : MonoBehaviour, IPointerClickHandler
{
    public CraftingRecipe recipe;
    public TMP_Text recipeText;

    // Start is called before the first frame update
    void Start()
    {
        recipeText.text = recipe.returnItem.item.itemName;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        CraftingManager.instance.UpdateSlot(recipe);
    }
}
