using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerMovement : MonoBehaviour{

    public float speed = 10f;
    public float jumpHeight = 7f;
    private Rigidbody2D body;
    private Animator anim;
    private bool facingRight = true;    
    private bool onGround;

    private Color pColour;

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

    void Update(){
        pColour = pColourChanger.pColour;
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
        if(other.gameObject.CompareTag("Obstacle")){
            //Debug.Log("I see you");
            //gets tilemap collider position and converts it into cell position
            //Vector3Int cellPos = other.GetComponent<Tilemap>().WorldToCell(transform.position);
            //Color tmapColor =  other.GetComponent<Tilemap>().GetColor(cellPos);
            Color tmapColor = other.gameObject.GetComponent<Tilemap>().color;
             
            /*if(tmap.GetColor(cellPos) != other.gameObject.GetComponent<playerColourChanger>().pColour){
                Debug.Log("Working so far");
                other.transform.position = GameManager.instance.getSpawnPoint().position;        
            } */
            if(tmapColor != pColour){
                transform.position = GameManager.instance.getCheckPoint().position;
                pColourChanger.changePlayerColour(Color.white);
                pColourChanger.reEnableCoins();

                //Debug.Log("tmap color "+tmapColor.ToHexString());
                //Debug.Log("player color "+pColour.ToHexString());
            }
        }    
    } 

    private void Flip(){
        Vector3 currentScale = gameObject.transform.localScale; 
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale; 
        facingRight = !facingRight; 
    }
}
