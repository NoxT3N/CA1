using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header("Coin Colour States")]
    //true = currently in scene
    //false = not in scene, will need to be respawned
    public bool whiteCoin = true;
    public bool redCoin = true;
    public bool yellowCoin = true;
    public bool blueCoin = true;

    [HideInInspector] public GameObject[]coins;

    void Awake(){
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
            return;
        }

        coins = GameObject.FindGameObjectsWithTag("Coin");
    }

    public bool getCoin(string coinName){
        coinName = coinName.ToLower();
        switch(coinName){

            case "white":
                return this.whiteCoin;
            case "red":
                return this.redCoin;
            case "yellow":
                return this.yellowCoin;
            case "blue":
                return this.blueCoin;
            default:
                return false;
        }
    }

    public void setCoin(String coinName,bool state){
        string coin = coinName;
         switch(coin){
            case "white":
                this.whiteCoin = state;
            break;
            case "red":
                this.redCoin = state;
            break;
            case "yellow":
                this.yellowCoin = state;
            break;
            case "blue":
                this.blueCoin = state;
            break;
            default:
            break;
        }
    }
}
