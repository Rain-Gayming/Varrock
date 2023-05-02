using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int gold;

    [Header("UI")]
    public List<ItemSlot> itemSlots;
    public List<ItemObject> items;
    //public List<int> amounts;
    public GameObject inventoryCanvas;
    public GameObject gameCanvas;
    public TMP_Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = gold.ToString();
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
}
