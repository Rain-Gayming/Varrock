using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveSpeed;
    public Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(InputManager.instance.walking.x, InputManager.instance.walking.y);
        move = move * moveSpeed * Time.deltaTime;
        rb2D.velocity = move;
    }
}
