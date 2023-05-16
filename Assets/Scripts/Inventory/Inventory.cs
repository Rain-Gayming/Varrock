using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int gold;
    [BoxGroup("UI")]
    public List<ItemSlot> itemSlots;
    [BoxGroup("UI")]
    public List<ItemObject> items;
    //public List<int> amounts;
    [BoxGroup("UI")]
    public GameObject inventoryCanvas;
    [BoxGroup("UI")]
    public GameObject gameCanvas;
    [BoxGroup("UI")]
    public ItemSlot hoveredSlot;
    [BoxGroup("UI")]
    public ItemSlot selectedSlot;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.instance.inventory){
            InputManager.instance.inventory = false;
            gameCanvas.SetActive(!gameCanvas.activeInHierarchy);
            inventoryCanvas.SetActive(!inventoryCanvas.activeInHierarchy);
            PlayerManager.instance.paused = !PlayerManager.instance.paused;
        }
    }

    public void CheckIfCanAddItem(GameObject objectFrom, Item itemToCheck, bool destroy)
    {
        int itemsCounted = 0;
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if(itemSlots[i].slotItem.item == itemToCheck.item && itemToCheck.item.stacks){
                itemSlots[i].slotItem.amount += itemToCheck.amount;
                //amounts[i] += itemToCheck.amount;
                if(destroy)
                    Destroy(objectFrom);
                return;
            }
            else if(itemSlots[i].slotItem.item == null)
            {
                itemSlots[i].slotItem = itemToCheck;
                //amounts.Add(itemToCheck.amount);
                items.Add(itemToCheck.item);
                if(destroy)
                    Destroy(objectFrom);
                return;
            }
            if(itemsCounted >= itemSlots.Count){
                return;
            }
        }
    }
    
    public void CheckIfCanAddItem(Item itemToCheck)
    {
        int itemsCounted = 0;
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if(itemSlots[i].slotItem.item == itemToCheck.item && itemToCheck.item.stacks){
                itemSlots[i].slotItem.amount += itemToCheck.amount;
                //amounts[i] += itemToCheck.amount;
                return;
            }
            else if(itemSlots[i].slotItem.item == null)
            {
                itemSlots[i].slotItem = itemToCheck;
                //amounts.Add(itemToCheck.amount);
                items.Add(itemToCheck.item);
                return;
            }
            if(itemsCounted >= itemSlots.Count){
                return;
            }
        }
    }

    public void UseItemsOnEachOther()
    {
        if(selectedSlot.slotItem.item != null && hoveredSlot.slotItem.item != null){

            for (int i = 0; i < selectedSlot.slotItem.item.itemInteractions.Count; i++)
            {
                if(selectedSlot.slotItem.item.itemInteractions[i].interactWith == hoveredSlot.slotItem.item){
                    selectedSlot.slotItem.amount--;
                    hoveredSlot.slotItem.amount--;
                    CheckIfCanAddItem(new Item(selectedSlot.slotItem.item.itemInteractions[i].itemResult, 1));
                    selectedSlot = null;
                    return;
                }
            }
        }else{
            selectedSlot = null;
        }
    }
}
