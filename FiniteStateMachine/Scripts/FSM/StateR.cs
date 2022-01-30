using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateR:BaseState
{
   public  override void StateChanger(StateManager s){
       if(Input.GetKey(KeyCode.R)){
           // do task 
            Debug.Log(  "pressed R");
            s.StateChanger(s.stt);
            Debug.Log("state changed to t");   
         
       }
      
   }
   
}
