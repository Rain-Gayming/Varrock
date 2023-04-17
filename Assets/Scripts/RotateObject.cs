using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public bool canRotate;
    public float mouseSensitvity;
    public Transform objectToRotate;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && canRotate){
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitvity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitvity * Time.deltaTime;

            objectToRotate.Rotate(Vector3.forward,  -mouseX);
        }
    }
}
