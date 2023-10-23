using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerMovement : MonoBehaviour{

    public float speed = 10f;
    public float jumpHeight = 7f;
    private Rigidbody2D body;
    private Animator anim;
    private bool facingRight = true;    
    private bool onGround;

    private playerColourChanger pColourChanger;

    
    
    private void Awake(){ 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pColourChanger = GetComponent<playerColourChanger>();
    }

    void FixedUpdate()
    {   
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput*speed, body.velocity.y);
        anim.SetBool("Walk", horizontalInput !=0);

        if(Input.GetKey(KeyCode.Space) && onGround){
            Jump();
        }

        if((horizontalInput>0 && !facingRight)||(horizontalInput<0 && facingRight))
        {
            Flip();
        }

    }

    private void Jump(){
        body.velocity = new Vector2(body.velocity.x, jumpHeight);
        anim.SetBool("Jump", true);
        anim.SetBool("Grounded",false);
        onGround = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("Wall")){
            onGround = true;
            anim.SetBool("Jump", false);
            anim.SetBool("Grounded",true);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        Vector3Int position = other.gameObject.GetComponent<Tilemap>().WorldToCell(transform.position);

        if(other.GetComponent<Tilemap>().GetColor(position) == pColourChanger.pColour){

        }
    }

    private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale; 
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale; 
        facingRight = !facingRight; 
    }
}
