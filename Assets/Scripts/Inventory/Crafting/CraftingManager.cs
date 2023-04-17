using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingManager : MonoBehaviour
{
    public static CraftingManager instance;
    public CraftingRecipe selectedRecipe;
    public List<CraftingRecipe> craftingRecipes;
    public TMP_Text recipeNameText;
    public TMP_Text descriptionText; 
    [Header("Slots")]
    public GameObject recipeSlot;
    public Transform recipeGrid;
    public List<GameObject> slots;
    public List<bool> hasItems;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateSlot(craftingRecipes[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSlot(CraftingRecipe recipeToUpdateTo)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            GameObject destroyedSlot = slots[i];
            slots.Remove(slots[i]);
            hasItems.Remove(hasItems[i]);
            Destroy(destroyedSlot);
        }
        recipeNameText.text = recipeToUpdateTo.returnItem.item.itemName;
        descriptionText.text = recipeToUpdateTo.returnItem.item.itemDescription;
        for (int i = 0; i < recipeToUpdateTo.itemsRequired.Count; i++)
        {
            GameObject newSlot = Instantiate(recipeSlot);
            newSlot.transform.SetParent(recipeGrid);
            newSlot.GetComponent<RecipeSlot>().item = recipeToUpdateTo.itemsRequired[i];
            slots.Add(newSlot); 
            hasItems.Add(false);
        }        
        selectedRecipe = recipeToUpdateTo;
    }

    public void CraftRecipe()
    {
        int itemsChecked = 0;
        int boolsChecked = 0;
        for (int i = 0; i < selectedRecipe.itemsRequired.Count; i++)
        {
            if(itemsChecked >= selectedRecipe.itemsRequired.Count){
                for (int b = 0; b < hasItems.Count; b++)
                {
                    if(hasItems[b] == true){
                        boolsChecked++;
                    }
                }
            }else{
                itemsChecked++;
            }
            
            CheckIfInventoryHasItem(selectedRecipe.itemsRequired[i].item, selectedRecipe.itemsRequired[i].amount, i);
        }

        if(boolsChecked >= hasItems.Count){
            Inventory.instance.CheckIfCanAddItem(selectedRecipe.returnItem);
        }else{
            Debug.Log("Inventory Didnt Have Every Item");
        }
    }

    public IEnumerator CheckIfInventoryHasItem(ItemObject itemToCheck, int itemAmount, int currentBool)
    {
        Debug.Log("Checking For item, " + itemToCheck.itemName + " With amount of: " + itemAmount.ToString());
        yield return new WaitForSeconds(0.1f);
        int itemsChecked = 0;
        for (int i = 0; i < Inventory.instance.itemSlots.Count; i++)
        {
            if(Inventory.instance.itemSlots[i].slotItem.item == itemToCheck && Inventory.instance.itemSlots[i].slotItem.amount >= itemAmount){
                hasItems[currentBool] = true;
            }else{
                itemsChecked++;
            }
            if(itemsChecked >= Inventory.instance.itemSlots.Count){
                hasItems[currentBool] = false;
            }
        }
    }
}
