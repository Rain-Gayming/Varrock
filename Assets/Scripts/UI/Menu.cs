using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName;
    public bool open;
    public GameObject reference;

    // Update is called once per frame
    void Update()
    {
        reference.SetActive(open);
    }
}
