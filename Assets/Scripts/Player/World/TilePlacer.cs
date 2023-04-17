using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TilePlacer : MonoBehaviour
{
    public Vector3 pos;
    public Vector3Int roundedPos;
    public RuleTile currentSelectedTile;
    public Tilemap tilemapToPlace;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);   
        roundedPos = new Vector3Int(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y), 0);     
        if(Input.GetMouseButtonDown(0)){
            tilemapToPlace.SetTile(roundedPos, currentSelectedTile);
        }
    }
}
