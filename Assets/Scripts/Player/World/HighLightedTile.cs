using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightedTile : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.x = Mathf.RoundToInt(pos.x);
        pos.y = Mathf.RoundToInt(pos.y);
        pos.z = 0;
        transform.position = pos;    
    }
}
