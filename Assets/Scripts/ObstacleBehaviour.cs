using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleBehaviour : MonoBehaviour
{   
    Tilemap tmap;
    // Start is called before the first frame update
    void Awake()
    {
        tmap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            //Debug.Log("I see you");
            //gets tilemap collider position and converts it into cell position
            //Vector3Int cellPos = tmap.WorldToCell(transform.position);
            Color tmapColor = tmap.GetComponent<Tilemap>().color;
            Color pColor = GameManager.instance.player.GetComponent<SpriteRenderer>().color;
            /*if(tmap.GetColor(cellPos) != other.gameObject.GetComponent<playerColourChanger>().pColour){
                Debug.Log("Working so far");
                other.transform.position = GameManager.instance.getSpawnPoint().position;        
            }*/
            if(tmapColor != pColor){
                //Debug.Log(tmapColor.ToHexString());
                //Debug.Log(pColor.ToHexString());
                other.transform.position = GameManager.instance.getSpawnPoint().position;
                
            }
        }    
    }
}
