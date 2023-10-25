using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerMovement : MonoBehaviour{
    
    [Header("Player settings")]
    public float speed = 10f;
    public float jumpHeight = 7f;
    //public float dashSpeed = 20f;
    //private bool isDashing = false; 
    //public float jumpCooldownDuration = 0.2f;
    //private bool canJump = true;
    private Rigidbody2D body;
    private Animator anim;
    private bool facingRight = true;    
    private bool onGround;
    private Color pColour;
    private playerColourChanger pColourChanger;

    //private bool dashInProgress = false;
   // private bool jumpInProgress = false;

    
    
    private void Awake(){ 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pColourChanger = GetComponent<playerColourChanger>();
    }

    void Start(){
        transform.position = GameManager.instance.getCheckPoint().position;
    }

    void FixedUpdate()
    {   
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontalInput*speed, body.velocity.y);
        anim.SetBool("Walk", horizontalInput !=0);

        if(Input.GetKey(KeyCode.Space) && onGround){
            Jump();
        }

        if((horizontalInput>0 && !facingRight)||(horizontalInput<0 && facingRight)){
            Flip();
        }

        
        /*if(Input.GetKey(KeyCode.LeftShift) && !isDashing && !dashInProgress){
            StartCoroutine(Dash());
        }*/

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

    /* IEnumerator jumpCooldown(){
        canJump = false;
        yield return new WaitForSeconds(jumpCooldownDuration);
        canJump = true;
    }*/

     /*IEnumerator Dash(){
        float originalSpeed = speed;
        speed = dashSpeed;
        isDashing = true;
        dashInProgress  = true;
        yield return new WaitForSeconds(0.2f);
        speed = originalSpeed;
        isDashing = false;
        dashInProgress = false;
        
     }*/


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
