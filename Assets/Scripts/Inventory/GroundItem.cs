using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public Item item;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Inventory.instance.CheckIfCanAddItem(gameObject, item);
        }
    }
}
