using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Sirenix.OdinInspector;

public class StatSlotDisplay : MonoBehaviour
{
    public Stat stat;
    [BoxGroup("UI")]
    public TMP_Text boostText;
    [BoxGroup("UI")]
    public TMP_Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boostText.text = stat.currentBoost.ToString();
        levelText.text = stat.currentLevel.ToString();

    }
}

[System.Serializable]
public class Stat
{
    public string statName;
    public float currentBoost;
    public float currentLevel;
    public float currentExp;
    public float expForNext;
}

[System.Serializable]
public class StatSlot
{
    public StatSlotDisplay display;
    public Stat stat;
}