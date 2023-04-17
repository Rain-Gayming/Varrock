using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public Transform camera;
    float scroll;
    RaycastHit buildHit; 
    public bool buildMode;

    [Header("Build")]
    public LayerMask buildMask;
    public GameObject buildObject;
    ConstructedObject mostRecentBuild;
    public float buildRotation;

    [Header("Ghost")]
    public GameObject buildGhostObject;
    GameObject currentGhostObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InputManager.instance.interact){
            buildMode = !buildMode;
            InputManager.instance.interact = false;
        }

        if(buildMode == true){
            //Building Rotation
            scroll = InputManager.instance.scrollWheel.y;
            scroll = Mathf.Clamp(scroll, -45, 45);
            //scroll = Mathf.RoundToInt(scroll);
            if(scroll > 0){
                scroll = -45;
            }else if(scroll < 0){
                scroll = 45;
            }
            Debug.Log(scroll);
            if(scroll != 0){

                buildRotation += scroll;
            }
            if(buildRotation < -180){
                buildRotation = 0;
            }
            if(buildRotation == 180){
                buildRotation = 0;
            }


            //Building   
            if(Physics.Raycast(camera.position, camera.forward, out buildHit, 25f, buildMask)){
                if(!currentGhostObject){

                    GameObject newGhost = Instantiate(buildGhostObject);
                    currentGhostObject = newGhost;
                }
                    
                if(buildHit.transform.tag == "snap point"){ 
                    currentGhostObject.transform.position = buildHit.transform.position;  
                }else{                    
                    currentGhostObject.transform.position = buildHit.point;  
                }              
                currentGhostObject.transform.eulerAngles = new Vector3(0, buildRotation, 0);

                if(Input.GetMouseButtonDown(0)){
                    GameObject newBuild = Instantiate(buildObject);
                    mostRecentBuild = newBuild.GetComponent<ConstructedObject>(); 
                    if(buildHit.transform.tag == "snap point"){
                        Debug.Log("Looking at a build point");
                        newBuild.transform.position = buildHit.transform.position;
                        newBuild.transform.GetComponent<ConstructedObject>().builtOnSnap = true;
                        newBuild.transform.GetComponent<ConstructedObject>().snapBuiltOff = buildHit.transform.GetComponent<SnapPoint>();
                    }else{
                        newBuild.transform.position = buildHit.point;
                    }
                    mostRecentBuild.GetComponent<ConstructedObject>().rotation = buildRotation;
                }

                if(InputManager.instance.altInteract && buildHit.transform.GetComponent<ConstructedObject>()){
                    Destroy(buildHit.transform.gameObject);
                }
            }
        }else{
            Destroy(currentGhostObject);
        }
    }
}