using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToTitleSceen : MonoBehaviour
{
  
    public void ToTitleScreen(){
        SceneManager.LoadScene("MainMenu");
    }   

}
