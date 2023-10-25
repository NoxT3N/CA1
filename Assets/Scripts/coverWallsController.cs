using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class coverWallsController : MonoBehaviour
{
    
    public GameObject coverWall;
    // Start is called before the first frame update
    void Awake()
    {
        //coverWall = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            coverWall.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        coverWall.SetActive(true);
    }
}
