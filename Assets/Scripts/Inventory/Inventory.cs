using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [Header("UI")]
    public List<ItemSlot> itemSlots;
    public GameObject inventoryCanvas;
    public GameObject gameCanvas;

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

    public void CheckIfCanAddItem(GameObject objectFrom, Item itemToCheck)
    {
        int itemsCounted = 0;
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if(itemSlots[i].slotItem.item == itemToCheck.item && itemToCheck.item.stacks){
                itemSlots[i].slotItem.amount += itemToCheck.amount;
                Destroy(objectFrom);
                return;
            }
            else if(itemSlots[i].slotItem.item == null)
            {
                itemSlots[i].slotItem = itemToCheck;
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
                return;
            }
            else if(itemSlots[i].slotItem.item == null)
            {
                itemSlots[i].slotItem = itemToCheck;
                return;
            }
            if(itemsCounted >= itemSlots.Count){
                return;
            }
        }
    }
}
