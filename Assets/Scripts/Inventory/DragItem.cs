using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragItem : MonoBehaviour
{
    public static DragItem instance;
    public ItemSlot fromSlot;
    public ItemSlot hoverSlot;
    public Trash trashSlot;
    public Image dragIcon;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
        if(fromSlot && fromSlot.slotItem.item){
            dragIcon.gameObject.SetActive(true);
            dragIcon.sprite = fromSlot.slotItem.item.itemIcon;
        }else{
            dragIcon.gameObject.SetActive(false);
        }
    }
    public void SwapItems()
    {
        if(trashSlot){
            fromSlot.slotItem = new Item();

            fromSlot = null;
            hoverSlot = null;
        }else if(hoverSlot != fromSlot){
            if(hoverSlot.anyItem){
                if(hoverSlot.slotItem.item != fromSlot.slotItem.item){
                    Item storedItem = fromSlot.slotItem;
                    fromSlot.slotItem = hoverSlot.slotItem;
                    hoverSlot.slotItem = storedItem;

                    fromSlot = null;
                    hoverSlot = null;
                }else{
                    hoverSlot.slotItem.amount += fromSlot.slotItem.amount;
                    fromSlot.slotItem =  new Item();
                    fromSlot = null;
                    hoverSlot = null;
                }
            }else if(!hoverSlot.anyItem && fromSlot.slotItem.item.itemType == hoverSlot.itemType){        
                Item storedItem = fromSlot.slotItem;
                fromSlot.slotItem = hoverSlot.slotItem;
                hoverSlot.slotItem = storedItem;

                fromSlot = null;
                hoverSlot = null;
            }else{
                Debug.Log("Placing item with type mismatch");
            }
        }else if(hoverSlot == fromSlot){
            fromSlot = null;
        }
    }
}
