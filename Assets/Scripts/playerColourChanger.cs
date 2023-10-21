using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class playerColourChanger : MonoBehaviour
{
    [HideInInspector]public Color pColour;
    private ColourNameHolder pColourNameHolder;
    private SpriteRenderer playerRender;
    private GameObject[] coins = CoinManager.instance.coins;

    void Awake(){
        playerRender = GetComponent<SpriteRenderer>();
        pColour = playerRender.color;    
        //coins = GameObject.FindGameObjectsWithTag("Coin");
        pColourNameHolder = GetComponent<ColourNameHolder>();
    }

    //when player enters a trigger collider it checks if that collider is tagged as coin
    //if yes then it gets the colour of the coin through its sprite render component
    //and check if it's the same with the player's colour
    //if not then the player's colour is changed to the coins colour 
    //through the sprite renderer component and the coin gets detroyed 
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coin")){
            //gets coin color
            Color coinColour = other.GetComponent<SpriteRenderer>().color;

            CoinManager.instance.setCoin(pColourNameHolder.ColourName,true);

            if(pColour != coinColour){
                //changes player colour to coin colour
                playerRender.material.color = coinColour;

                //gets coin colour name
                string colourName = other.GetComponent<ColourNameHolder>().ColourName;

                //sets player's colour name to coin's colour name
                pColourNameHolder.setColourName(colourName);
                //Destroy(other.gameObject);

                foreach(GameObject coin in coins){
                    if(coin.GetComponent<SpriteRenderer>().color == coinColour){
                        Destroy(coin);
                    }
                }

                //because the coins are destroyed we changed their state to false in CoinManager
                CoinManager.instance.setCoin(colourName,false);
            }
            
        }
    }
}