using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerTracker : MonoBehaviour
{
    [Header("Tracker Settings")]
   public Transform follow;
   public float offset;
   [HideInInspector] public Camera mainCamera;

    
    void Awake(){
        mainCamera = GetComponent<Camera>(); 
    }

    // Update is called once per frame
   
    void Update()
    {   //uses transform class to change the camera's position using the follow object's x position + an offset for further adjustment
        mainCamera.transform.position = new Vector3(follow.position.x+offset,4.12f,-10);
    }
}
