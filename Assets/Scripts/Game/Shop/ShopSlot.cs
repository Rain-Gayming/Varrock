using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item slotItem;
    public bool hovered;

    [Header("Display Info")]
    public Image hoverImage;
    public Image itemIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slotItem.amount = 1;    
        hoverImage.gameObject.SetActive(hovered);
        if(slotItem.item){
            itemIcon.gameObject.SetActive(true);
            itemIcon.sprite = slotItem.item.itemIcon;
        }else if(slotItem.item == null){
            itemIcon.gameObject.SetActive(false);
        }
        if(hovered){
            if(DragItem.instance){
                DragItem.instance.shopSlot = this;
            }
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                ShopManager.instance.currentSlot = this;
            }
            if(Input.GetMouseButtonDown(0)){
                DragItem.instance.SwapItems();
            }
        }else{
            DragItem.instance.shopSlot = null;  
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
