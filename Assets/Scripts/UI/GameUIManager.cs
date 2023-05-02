using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager instance;
    public GameObject shopUI;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Inventory.instance.inventoryCanvas.activeInHierarchy && InputManager.instance.inventory){
            shopUI.SetActive(false);
            ShopManager.instance.shopInfo = null;    
        }
    }

    public void OpenShop(ShopObject shopToOpen)
    {
        shopUI.SetActive(true);
        ShopManager.instance.shopInfo = shopToOpen;
    }
}
