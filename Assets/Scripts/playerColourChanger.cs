using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playerColourChanger : MonoBehaviour
{
    [HideInInspector]public Color pColour;
    [HideInInspector]public SpriteRenderer playerRender;
    private GameObject[] coins; 

    void Awake(){
        playerRender = GetComponent<SpriteRenderer>();
        pColour = playerRender.color;    
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }

    //when player enters a trigger collider it checks if that collider is tagged as coin
    //if yes then it gets the colour of the coin through its sprite render component
    //and check if it's the same with the player's colour
    //if not then the player's colour is changed to the coins colour 
    //through the sprite renderer component and the coin gets detroyed 
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coin")){
            Color coinColour = other.GetComponent<SpriteRenderer>().color;
            if(pColour != coinColour){
                playerRender.material.color = coinColour;
                //Destroy(other.gameObject);
                foreach(GameObject coin in coins){
                    if(coin.GetComponent<SpriteRenderer>().color == coinColour){
                        Destroy(coin);
                    }
                }
            }
            
        }
    }
}