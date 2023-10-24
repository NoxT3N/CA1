using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [HideInInspector] public Transform checkpoint;

    // Start is called before the first frame update
    void Awake()
    { 
        checkpoint = GetComponent<Transform>(); 
    }

    void Start(){
        checkpoint = GameManager.instance.getCheckPoint();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.setCheckPoint(checkpoint);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            Debug.Log("Checkpoint saved");
            checkpoint.position = transform.position;
            other.GetComponent<playerColourChanger>().changePlayerColour(Color.white);
            other.GetComponent<playerColourChanger>().reEnableCoins();
        }
    }
}
