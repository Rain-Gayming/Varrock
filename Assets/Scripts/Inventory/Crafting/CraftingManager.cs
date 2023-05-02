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
    bool checkForCraft;
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
        descriptionText.text = recipeToUpdateTo.returnItem.item.itemInfo;
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
            for (int i = 0; i < selectedRecipe.itemsRequired.Count; i++)
            {
                StartCoroutine(CheckIfInventoryHasItem(selectedRecipe.itemsRequired[i]));
            }
        }

        public IEnumerator CheckIfInventoryHasItem(Item itemToCheck)
        {
            Debug.Log("Checking For item, " + itemToCheck.item.itemName + " With amount of: " + itemToCheck.amount.ToString());
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < Inventory.instance.itemSlots.Count; i++)
            {
                /*if(Inventory.instance.amounts.Contains(itemToCheck.amount)){
                    if(Inventory.instance.items.Contains(itemToCheck.item)){
                        Debug.Log("should craft item");
                    }
                }*/
            }
        }
    }

/* public void CraftRecipe()
    {
        for (int i = 0; i < selectedRecipe.itemsRequired.Count; i++)
        {
            CheckIfInventoryHasItem(selectedRecipe.itemsRequired[i]);
        }
    }

    public IEnumerator CheckIfInventoryHasItem(Item itemToCheck)
    {
        Debug.Log("Checking For item, " + itemToCheck.item.itemName + " With amount of: " + itemToCheck.amount.ToString());
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < Inventory.instance.itemSlots.Count; i++)
        {
            if(Inventory.instance.amounts.Contains(itemToCheck.amount)){
                if(Inventory.instance.items.Contains(itemToCheck.item)){
                    Debug.Log("should craft item");
                }
            }
        }
    }*/
