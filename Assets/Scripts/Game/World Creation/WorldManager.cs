using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static WorldManager instance;
    public bool shouldLoadMap;
    public TerrainGenerator terrainGenerator;
	public HeightMapSettings heightMapSettings;

    public WorldData worldData;

    private void Awake() {
        instance = this; 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        terrainGenerator.enabled = shouldLoadMap;
        if(shouldLoadMap){
            heightMapSettings.noiseSettings.seed = worldData.worldSeed;
        }
    }
}
