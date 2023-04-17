using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Clickable
{
    public LootRoll roll;
    public List<Loot> loots;
    public GameObject groundItem;
    public ParticleSystem breakEffect;
    public bool opened;
    
    public override void Interact()
    {
        if(!opened){
            opened = true;
            loots.Clear();
            Roll(roll.minimumRoll, roll.maximumRoll);
            breakEffect.Play();
            Destroy(gameObject);
        }
    }
    public void Roll(int minRoll, int maxRoll)
    {
        int rolls = Random.Range(minRoll, maxRoll);

        for (int i = 0; i < rolls; i++)
        {
            loots.Add(roll.myTable.GetRandomItem());
            GameObject newItem = Instantiate(groundItem);
            newItem.GetComponent<GroundItem>().item = loots[i].item;
        }
    }
}
