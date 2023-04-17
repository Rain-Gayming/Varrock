using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool hovered;
    private void Update() {
        if(hovered){
            DragItem.instance.trashSlot = this;
            if(Input.GetMouseButtonDown(0)){
                DragItem.instance.SwapItems();
            }
        }else{
            DragItem.instance.trashSlot = null;
        }
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }
}
