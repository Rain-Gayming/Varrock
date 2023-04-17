using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPerspective : MonoBehaviour
{
    public CinemachineVirtualCamera vCam;

    public void UpdatePoint(GameObject point)
    {
        vCam.LookAt = point.transform;
        vCam.Follow = point.transform;
    }
}
