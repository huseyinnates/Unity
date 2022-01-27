using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : SlowMotion
{

    public float slowfactor=0.05f;
    // Update is called once per frame
    void Start(){

    }
    void Update()
    {
        if(Input.GetButton("Fire1")){
          SceneSpeed(slowfactor);   
        }
        if(Input.GetButton("Fire2")){
           SceneSpeed(slowfactor); 
        }
        
        
    }
}
