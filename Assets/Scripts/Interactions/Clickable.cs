using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
    public void OnMouseClick()
    {
        Interact();
    }
    public abstract void Interact();
}
