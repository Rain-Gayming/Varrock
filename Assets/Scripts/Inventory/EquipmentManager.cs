using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public List<ItemSlot> equipmentSlots;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipItem(ItemSlot fromSlot, Item itemToEquip)
    {
        for (int i = 0; i < equipmentSlots.Count; i++)
        {
            if(itemToEquip.item.itemType == equipmentSlots[i].itemType){
                fromSlot.slotItem = equipmentSlots[i].slotItem;
                equipmentSlots[i].slotItem = itemToEquip;
                return;
            }
        }
    }
}
