using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chest_anim_Script : MonoBehaviour
{
    private Animator anim;
    void Awake(){
        anim = GetComponent<Animator>();
    }
    

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            anim.SetBool("open",true);
        }
        StartCoroutine(waitForEndGame());  
    }

    IEnumerator waitForEndGame(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }
}
