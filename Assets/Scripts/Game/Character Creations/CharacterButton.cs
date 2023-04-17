using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CharacterButton : MonoBehaviour
{   
    [Header("UI")]
    public TMP_Text characterNameText;

    public CharacterData myCharacterData;

    // Start is called before the first frame update
    void Start()
    {
        characterNameText.text = myCharacterData.name;
    }

    public void LoadCharacter()
    {
        CharacterManager.instance.LoadCharacter(myCharacterData);
        GetComponentInParent<MenuManager>().OpenMenu("Worlds");
    }
}
