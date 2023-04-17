using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item slotItem;
    public Item preItem;
    public bool hovered;

    [Header("Display Info")]
    public Image hoverImage;
    public TMP_Text amountText;
    public Image itemIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hoverImage.gameObject.SetActive(hovered);
        if(slotItem.item){
            itemIcon.gameObject.SetActive(true);
            itemIcon.sprite = slotItem.item.itemIcon;
            if(slotItem.amount > 1){
                amountText.gameObject.SetActive(true);
                amountText.text = slotItem.amount.ToString();
            }else{
                amountText.gameObject.SetActive(false);
            }
        }else if(slotItem.item == null){
            itemIcon.gameObject.SetActive(false);
            amountText.gameObject.SetActive(false);
        }
        if(hovered){
            DragItem.instance.hoverSlot = this;
            
            if(DragItem.instance.fromSlot == null && InputManager.instance.leftMouse){
                DragItem.instance.fromSlot = this;
                InputManager.instance.leftMouse = false;
            }else if(DragItem.instance.fromSlot != null && InputManager.instance.leftMouse){
                DragItem.instance.SwapItems();
                InputManager.instance.leftMouse = false;
            }
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }    
}
