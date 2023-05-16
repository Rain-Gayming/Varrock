using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;
    public Camera cam;

    [Header("Scrolling")]
    public float scrollSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {  
        //Zoom Camera
        if(Input.GetAxis("Mouse ScrollWheel") != 0){
            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
            cam.orthographicSize -= scrollDelta * Time.deltaTime * scrollSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 3f, 10);
        }
    }
}
