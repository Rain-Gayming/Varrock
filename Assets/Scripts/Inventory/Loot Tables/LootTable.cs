using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loot/LootTable")]
public class LootTable : ScriptableObject
{
    public List<Loot> loot;
    public int totalWeight;

    private bool isInitialized = false;

    [ContextMenu("Initialize")]
    public void Initialize()
    {
        totalWeight = 0;
        if(!isInitialized){
            for (int i = 0; i < loot.Count; i++)
            {
                totalWeight += loot[i].weight;
                if(i >= loot.Count){
                    isInitialized = true;
                }
            }
        }
    }   

    public Loot GetRandomItem()
    {
        Initialize();

        int diceRoll = Random.Range(0, totalWeight);
        Debug.Log(diceRoll);

        foreach(var item in loot)
        {
            if(item.weight >= diceRoll){
                item.item.amount = Random.Range(item.minimumAmount, item.maximumAmount);
                Debug.Log("Giving item of: " + item.item.item.itemName + " with amount of: " + item.item.amount); 
                return item;
            }
            diceRoll -= item.weight;
        }
        throw new System.Exception("Reward Generation Failed");
    }
}
