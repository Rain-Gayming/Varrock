using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotbarDisplay : MonoBehaviour
{
    public ItemSlot slotInfoFrom;
    public int slotID;
    [Header("Display Info")]
    public TMP_Text amountText;
    public TMP_Text slotText;
    public Image itemIcon;
    // Start is called before the first frame update
    void Start()
    {
        slotText.text = slotID.ToString();
        //slotInfoFrom = Inventory.instance.itemSlots[slotID];
    }

    // Update is called once per frame
    void Update()
    {
        if(slotInfoFrom.slotItem.item){
            itemIcon.gameObject.SetActive(true);
            itemIcon.sprite = slotInfoFrom.slotItem.item.itemIcon;
            if(slotInfoFrom.slotItem.amount > 1){
                amountText.gameObject.SetActive(true);
                amountText.text = slotInfoFrom.slotItem.amount.ToString();
            }else{
                amountText.gameObject.SetActive(false);
            }
        }else{
            itemIcon.gameObject.SetActive(false);
            amountText.gameObject.SetActive(false);
        }        
    }
}
