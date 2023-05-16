using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public List<StatSlot> stats;
    public float expDif;
    public float expGap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < stats.Count; i++)
        {
            stats[i].display.stat = stats[i].stat;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            AddExp("Attack", 100);
        }
    }

    public void AddExp(string statName, float exp)
    {
        for (int i = 0; i < stats.Count; i++)
        {   
            if(stats[i].stat.statName == statName){
                stats[i].stat.currentExp += exp;
            }
            if(stats[i].stat.currentExp >= stats[i].stat.expForNext)
            {
                stats[i].stat.currentLevel++;
                stats[i].stat.expForNext = ((stats[i].stat.currentLevel/expDif) * stats[i].stat.currentLevel * 1.5f)*stats[i].stat.currentLevel;
            }
        }
    }

    public void StatBoostChange(string statName, float boost)
    {
        for (int i = 0; i < stats.Count; i++)
        {   
            if(stats[i].stat.statName == statName){
                stats[i].stat.currentBoost += boost;
            }
        }
    }
    public void StatLevelChange(string statName, float change)
    {
        for (int i = 0; i < stats.Count; i++)
        {   
            if(stats[i].stat.statName == statName){
                stats[i].stat.currentLevel += change;
            }
        }
    }
}
