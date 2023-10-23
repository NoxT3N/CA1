using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager instance; 

    [Header("Respawm point settings")]
    public GameObject player;
    public Transform spawnPoint;
   
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Transform getSpawnPoint(){
        return this.spawnPoint;
    }

    
}
