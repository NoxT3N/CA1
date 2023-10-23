using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class playerColourChanger : MonoBehaviour
{
    [HideInInspector] public Color pColour;
    [HideInInspector] public Color coinColour;
    private SpriteRenderer playerRender;
    private GameObject[] coins; 

    void Awake(){
        playerRender = GetComponent<SpriteRenderer>();
        pColour = playerRender.color;    
        coins = GameObject.FindGameObjectsWithTag("Coin");
    }

    void Update(){
        pColour = playerRender.material.color;
    }

    //when player enters a trigger collider it checks if that collider is tagged as coin
    //if yes then it gets the colour of the coin through its sprite render component
    //and check if it's the same with the player's colour
    //if not then the player's colour is changed to the coins colour 
    //through the sprite renderer component and the coin gets detroyed

    //UPDATE: instead of destroying the coin now ther's a loop that goes thorugh each coin in the game and disable's it if it's the same colour

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Coin")){
            for(int i = 0; i < GameObject.Find("Coins").transform.childCount; i++){ 
                //Because Find(parentName) checks disabled objects by default I used it to reenablethe coins
                GameObject.Find("Coins").transform.GetChild(i).gameObject.SetActive(true);
            }

            if(other.gameObject.CompareTag("Coin")){
                 coinColour = other.GetComponent<SpriteRenderer>().color;
                if(pColour != coinColour){  
                    //Destroy(other.gameObject);
                    foreach(GameObject coin in coins){
                        if(coin.GetComponent<SpriteRenderer>().color == coinColour){
                            coin.SetActive(false);
                        }
                        
                    }
                    playerRender.material.color = coinColour;
                }
                
            }
        }
    }
}