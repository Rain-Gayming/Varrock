using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public bool paused;
    public bool inGame;
    public CharacterData characterData;

    [Header("Camera")]
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(inGame){
            playerCamera.SetActive(true);
            if(InputManager.instance.pause){
                paused = !paused;
                InputManager.instance.pause = false;
            }
        }else{
            playerCamera.SetActive(false);
        }
    }
}

