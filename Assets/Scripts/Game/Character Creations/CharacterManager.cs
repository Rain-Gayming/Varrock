using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    string saveFile;
    CharacterFileData savedCharacterFileData = new CharacterFileData();
    CharacterFileData playerCharacterFileData = new CharacterFileData();
    int loadedCharacter;

    [Header("Character UI")]
    public GameObject characterButton;
    public Transform characterButtonPosition;
    public TMP_Text nameInput;
    public TMP_Text alreadyExistsText;
    public TMP_Text hairText;
    public TMP_Text beardText;

    [Header("Character Values")]
    public string characterName;
    public int characterHair;
    public int characterBeard;
    public bool isMale;
    public Color characterHairColour;
    public Color characterSkinColour;

    [Header("Character Display")]
    public Material skinMaterial;
    public Material hairMaterial;
    
    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        saveFile = Application.persistentDataPath + "/" + "Characters" + ".json";
        ReadFile();
    }

    // Update is called once per frame
    void Update()
    {
        skinMaterial.color = characterSkinColour;
        hairMaterial.color = characterHairColour;
        characterName = nameInput.text;

        characterHair = Mathf.Clamp(characterHair, 0, 17);
        hairText.text = "Hair (" + characterHair.ToString() + ")";
        
        characterBeard = Mathf.Clamp(characterBeard, 0, 10);
        beardText.text = "Beard (" + characterBeard.ToString() + ")";
        


        if(Input.GetKeyDown(KeyCode.T)){
            SaveCharacter();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            SaveCharacters();
        }

        if(PlayerManager.instance){
            PlayerManager.instance.characterData.isMale = isMale;   
            PlayerManager.instance.characterData.beard = characterBeard;
            PlayerManager.instance.characterData.hair = characterHair;
            PlayerManager.instance.characterData.hairColour = characterHairColour;
            PlayerManager.instance.characterData.skinColour = characterSkinColour;
        }
    }

    [ContextMenu("Load")]
    public void ReadFile()
    {
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);
            
            savedCharacterFileData = JsonUtility.FromJson<CharacterFileData>(fileContents);

            playerCharacterFileData = savedCharacterFileData;

            for (int i = 0; i < playerCharacterFileData.characterDatas.Count; i++)
            {
                GameObject newButton = Instantiate(characterButton);
                newButton.transform.SetParent(characterButtonPosition);
                newButton.transform.localScale = Vector3.one;
                
                newButton.GetComponent<CharacterButton>().myCharacterData = playerCharacterFileData.characterDatas[i];
            }
        }
    }

    public void SaveCharacter()
    {
        alreadyExistsText.gameObject.SetActive(false);
        CharacterData newData = new CharacterData();
        newData.name = characterName;
        newData.isMale = isMale;
        newData.hair = characterHair;
        newData.beard = characterBeard;
        newData.hairColour = characterHairColour;
        newData.skinColour = characterSkinColour;
            
        Debug.Log(playerCharacterFileData);
        Debug.Log(playerCharacterFileData.characterDatas);
        playerCharacterFileData.characterDatas.Add(newData);

        /*    
        if(playerCharacterFileData.characterDatas.Count > 0){

            int counted = 0;
            for (int i = 0; i < playerCharacterFileData.characterDatas.Count; i++)
            {
                if(playerCharacterFileData.characterDatas[i].name == characterName){
                    alreadyExistsText.gameObject.SetActive(true);
                    return;
                }else{
                    counted++;
                }
                if(counted > playerCharacterFileData.characterDatas.Count){
                    playerCharacterFileData.characterDatas.Add(newData);
                }
            }
        }else{
            playerCharacterFileData.characterDatas.Add(newData);
        }*/
        SaveCharacters();
    }
    public void SaveCharacters()
    {
        saveFile = Application.persistentDataPath + "/" + "Characters" + ".json";
        
        
        savedCharacterFileData.characterDatas = playerCharacterFileData.characterDatas;
        
        Debug.Log(saveFile);

        string jsonString = JsonUtility.ToJson(savedCharacterFileData, true);

        File.WriteAllText(saveFile, jsonString);

    }

    public void LoadCharacter(CharacterData character)
    {
        characterName = character.name;
        isMale = character.isMale;
        characterHair = character.hair;
        characterBeard = character.beard;
        characterHairColour = character.hairColour;
        characterSkinColour = character.skinColour;
    }

    public void ChangeHair(int change)
    {
        characterHair += change;
    }

    public void ChangeBeard(int change)
    {
        characterBeard += change;
    }

    public void ChangeSkinColour(Image color)
    {
        characterSkinColour = color.color;
    }
    public void ChangeHairColour(Image color)
    {
        characterHairColour = color.color;
    }
    public void ReloadCharacters()
    {
        SaveCharacters();
        ReadFile();
    }

    public void SetFemale()
    {
        isMale = false;
    }

    public void SetMale()
    {
        isMale = true;
    }

    public void ChangeCharacter(int characterChange)
    {
        loadedCharacter += characterChange;
        LoadCharacter(playerCharacterFileData.characterDatas[loadedCharacter]);
    }
}

[System.Serializable]
public class CharacterFileData
{
    public List<CharacterData> characterDatas;
}
[System.Serializable]
public class CharacterData
{
    public string name;
    public bool isMale;
    public int hair;
    public int beard;
    public Color hairColour;
    public Color skinColour;
}