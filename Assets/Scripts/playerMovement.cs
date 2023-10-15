using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour{

    public float speed = 10f;
    public float jumpHeight = 7f;
    private Rigidbody2D body;
    private Animator anim;
    private bool facingRight = true;    
    private bool onGround;
    
    private void Awake(){ //method called when the unity scene is loaded
        //refrences the components attached to the game object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {   
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput*speed, body.velocity.y);
        
        if(Input.GetKey(KeyCode.Space) && onGround){
            Jump();
        }
        

        anim.SetBool("walk", horizontalInput !=0);

    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        anim.SetTrigger("jump");
        onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground"))
        onGround = true;
    }
}
