using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Clickable
{
    public ShopObject myShop;
    public override void Interact()
    {
        GameUIManager.instance.OpenShop(myShop);
    }
}
