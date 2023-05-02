using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Player : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Animator anim;
    public Rigidbody2D rb2D;
    [Header("Movement")]
    public float moveSpeed;
    public Vector2 move;
    public Vector2 recentMove;
    [Header("Combat")]
    public bool canAttack;
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

        anim.SetFloat("X", move.x);
        anim.SetFloat("Y", move.y);

        if(move.x != 0){
            recentMove.x = move.x;
        }
        if(move.y != 0){
            recentMove.y = move.y;
        }

        if(InputManager.instance.leftMouse){
            anim.SetBool("Attacking", true);
        }else{
            anim.SetBool("Attacking", false);
        }
    }
}
