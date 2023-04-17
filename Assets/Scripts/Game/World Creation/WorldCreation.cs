using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldCreation : MonoBehaviour
{
    string saveFile;
    public WorldData worldData = new WorldData();
    WorldFileData savedWorldFileData;
    WorldFileData playerWorldFileData;

    [Header("UI")]
    public GameObject worldButton;
    public Transform worldButtonPosition;
    public TMP_Text worldNameInput;
    public TMP_Text worldSeedInput;
    public TMP_Text alreadyExistsText;
    // Start is called before the first frame update
    void Start()
    {
        saveFile = Application.persistentDataPath + "/" + "Worlds" + ".json";
        ReadFile();
    }

    private void Update() {
        worldData.worldName = worldNameInput.text;
        worldData.worldSeed = worldSeedInput.text;
    }

    [ContextMenu("Load")]
    public void ReadFile()
    {
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);
            
            savedWorldFileData = JsonUtility.FromJson<WorldFileData>(fileContents);

            playerWorldFileData = savedWorldFileData;

            for (int i = 0; i < playerWorldFileData.worldDatas.Count; i++)
            {
                GameObject newButton = Instantiate(worldButton);
                newButton.transform.SetParent(worldButtonPosition);
                newButton.transform.localScale = Vector3.one;
                
                //newButton.GetComponent<CharacterButton>().myCharacterData = playerWorldFileData.worldDatas[i];
            }
        }
    }

    public void SaveWorld()
    {
        alreadyExistsText.gameObject.SetActive(false);

        Debug.Log(playerWorldFileData);
        Debug.Log(playerWorldFileData.worldDatas);

        playerWorldFileData.worldDatas.Add(worldData);
    }
    public void SaveWorlds()
    {
        saveFile = Application.persistentDataPath + "/" + "Worlds" + ".json";
        
        
        savedWorldFileData.worldDatas = playerWorldFileData.worldDatas;
        
        Debug.Log(saveFile);

        string jsonString = JsonUtility.ToJson(savedWorldFileData);

        File.WriteAllText(saveFile, jsonString);

    }

    public void CreateWorld()
    {
        if(worldSeedInput.text == null){
            worldSeedInput.text = Random.Range(-10000, 10000).ToString();
        }
        SaveWorld();
        //SaveWorlds();
    }

}


[System.Serializable]
public class WorldFileData
{
    public List<WorldData> worldDatas;
}
[System.Serializable]
public class WorldData
{
    public string worldName;
    public string worldSeed;
}