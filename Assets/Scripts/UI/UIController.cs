using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public GameObject firstButton;

    public GameObject fpsCounter;
    private void Awake() 
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeSelectedButton(firstButton);
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.instance.fpsToggle){
            InputManager.instance.fpsToggle = false;
            fpsCounter.SetActive(!fpsCounter.activeInHierarchy);
        }
    }

    public void ChangeSelectedButton(GameObject button)
    {
        EventSystem.current.SetSelectedGameObject(null);
        
        EventSystem.current.SetSelectedGameObject(button);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeObjectActive(GameObject _object)
    {
        _object.SetActive(!_object.activeInHierarchy);
    }
}
