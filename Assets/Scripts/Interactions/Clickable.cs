using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
    public void OnMouseDown()
    {
        Interact();
    }
    public abstract void Interact();
}
