using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class coverWallsController : MonoBehaviour
{
    //private bool fakeWall;
    private Color originalColor;
    private float newAlpha = 0f;
    private Tilemap fakeWall;
    void Awake()
    {
        //coverWall = GetComponent<GameObject>();
        fakeWall = GetComponent<Tilemap>();
        originalColor = fakeWall.color;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(fakeWall){
            this.gameObject.SetActive(true);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            //Debug.Log("Inside");
            //this.gameObject.SetActive(false);
            //fakeWall = false;
            Color colour = fakeWall.color;
            colour.a = newAlpha;
            fakeWall.color = colour;

        }
    }
    private void OnTriggerExit2D(Collider2D other){
        //Debug.Log("Outside");
        //this.gameObject.SetActive(true);
        //fakeWall = true;
        fakeWall.color = originalColor;
    }

    /*private void  OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("Toasters");
            coverWall.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
         if(other.gameObject.CompareTag("Player")){
            Debug.Log("Toasters");
            coverWall.SetActive(true);
        }
    }*/
}
