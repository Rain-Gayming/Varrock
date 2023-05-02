using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public SpriteRenderer sr;
    public Item item;

    private void Update() {
        if(sr.sprite != item.item.itemIcon){
            sr.sprite = item.item.itemIcon;
        }
    }
    private void OnMouseDown() {
        Inventory.instance.CheckIfCanAddItem(gameObject, item, true);
    }
}
