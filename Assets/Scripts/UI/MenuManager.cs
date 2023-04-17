using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public Menu[] menus;

    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //menus = GetComponentsInChildren<Menu>();
    }

    public void OpenMenu(Menu menuToOpen)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].open = false;
            menuToOpen.open = true;
        }
    }
    

    public void OpenMenu(string menuToOpen)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].open = false;
            if(menus[i].menuName == menuToOpen){
                menus[i].open = true;
            }
        }
    }
}
