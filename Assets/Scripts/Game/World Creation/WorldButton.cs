using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class WorldButton : MonoBehaviour, IPointerClickHandler
{   
    [Header("UI")]
    public TMP_Text worldNameText;

    public WorldData myWorldData;

    // Start is called before the first frame update
    void Start()
    {
        worldNameText.text = myWorldData.worldName;
    }

    public void LoadCharacter()
    {
        //CharacterManager.instance.LoadCharacter(myWorldData);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        PlayerManager.instance.inGame = true;
        WorldManager.instance.shouldLoadMap = true;
        TerrainGenerator.instance.canGenerate = true;
        SceneManager.LoadScene("DevScene");
    }
}
