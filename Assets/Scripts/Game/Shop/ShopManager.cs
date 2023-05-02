using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public ShopObject shopInfo;
    public ShopSlot currentSlot;
    public List<ShopSlot> shopSlots;

    [Header("Shop Info")]
    public TMP_Text itemNameText;
    public TMP_Text itemTypeText;
    public TMP_Text itemInfoText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;    
    }

    // Update is called once per frame
    void Update()
    {
        if(shopInfo){
            for (int i = 0; i < shopInfo.itemsInShop.Count; i++)
            {
                shopSlots[i].slotItem.item = shopInfo.itemsInShop[i];
            }
        }
        if(currentSlot.slotItem.item){
            itemNameText.text = currentSlot.slotItem.item.itemName;
            itemTypeText.text = currentSlot.slotItem.item.itemType.ToString();
            itemInfoText.text = currentSlot.slotItem.item.itemInfo + "\n" + "\n" + currentSlot.slotItem.item.itemDescription;
        }
    }
    public void BuyItem()
    {
        if(Inventory.instance.gold > currentSlot.slotItem.item.buyPrice){
            Inventory.instance.gold -= currentSlot.slotItem.item.buyPrice;
            Inventory.instance.CheckIfCanAddItem(gameObject, currentSlot.slotItem, false);
        }
    }
}
