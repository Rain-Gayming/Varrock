using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructedObject : MonoBehaviour
{
    public float rotation;
    public float placementDifference;
    public bool builtOnSnap;
    public SnapPoint snapBuiltOff;

    // Start is called before the first frame update
    void Start()
    {
        if(builtOnSnap){
            if(snapBuiltOff.right){
                float newX = transform.position.x;
                newX += transform.GetComponent<ConstructedObject>().placementDifference;
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
            else if(snapBuiltOff.left){
                float newX = transform.position.x;
                newX -= transform.GetComponent<ConstructedObject>().placementDifference;
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
            else if(snapBuiltOff.top){
                float newY = transform.position.y;
                newY += transform.GetComponent<ConstructedObject>().placementDifference + 1;
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else if(snapBuiltOff.bottom){
                float newY = transform.position.y;
                newY -= transform.GetComponent<ConstructedObject>().placementDifference + 1;
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        float newRot = rotation;
        transform.eulerAngles = new Vector3(0, newRot, 0);    
    }
}
