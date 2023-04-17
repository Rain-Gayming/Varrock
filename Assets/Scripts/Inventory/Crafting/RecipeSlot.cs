using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class RecipeSlot : MonoBehaviour
{
    public Item item;
    public TMP_Text amountText;
    public Image itemIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(item.item != null){
            itemIcon.sprite = item.item.itemIcon;
            if(item.amount > 1){
                amountText.gameObject.SetActive(true);
                amountText.text = item.amount.ToString();
            }else{
                amountText.gameObject.SetActive(false);
            }
        }else{
            Destroy(gameObject);
        }
    }
}
