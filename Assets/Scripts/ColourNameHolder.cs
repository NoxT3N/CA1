using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ColourNameHolder : MonoBehaviour
{  
    [Header("Name of the colour of the coin")]
    public String ColourName;

    public void setColourName(String name){
        this.ColourName = name;
    }
    
}
