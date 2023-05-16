using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Sirenix.OdinInspector;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Inventory inventory;
    public Item slotItem;

    [BoxGroup("Specific Items")]
    public bool anyItem;
    [BoxGroup("Specific Items")]
    public EItemType itemType;

    [BoxGroup("Display")]
    public Image hoverImage;
    [BoxGroup("Display")]
    public TMP_Text amountText;
    [BoxGroup("Display")]
    public Image itemIcon;

    [BoxGroup("Dragging")]
    public float mouseDragTime = 0.1f;
    [BoxGroup("Dragging")]
    public DragItem dragItem;
    [BoxGroup("Dragging")]
    public bool hovered;
    float mouseDragTimer;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponentInParent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slotItem.amount <= 0){
            slotItem = new Item(null, 0);
        }
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
            if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift) && hovered){
                EquipmentManager.instance.EquipItem(this, slotItem);
            }
        }else if(slotItem.item == null){
            itemIcon.gameObject.SetActive(false);
            amountText.gameObject.SetActive(false);
        }
        if(hovered){
            dragItem.hoverSlot = this;
            if(slotItem.item != null && dragItem.fromSlot == null)
                inventory.hoveredSlot = this;
            
            if(Input.GetMouseButton(0))
            {
                mouseDragTimer += Time.deltaTime;

                //if the mouse has been held for longer than minimum time then it drags it, else it selects it
                if(mouseDragTimer > mouseDragTime){
                    if(dragItem.fromSlot == null && !Input.GetKey(KeyCode.LeftShift)){
                        dragItem.fromSlot = this;
                        mouseDragTimer = 0;
                    }
                }                
            }else{
                mouseDragTimer = 0;
            }
            if(Input.GetMouseButtonDown(0)){  
                if(inventory.selectedSlot){
                    inventory.UseItemsOnEachOther();
                }else{
                    inventory.selectedSlot = this;
                }       
            }
            if(dragItem.fromSlot != null && !InputManager.instance.leftMouse && !Input.GetKey(KeyCode.LeftShift)){
                dragItem.SwapItems();
                //mouseDragTimer = 0;
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
