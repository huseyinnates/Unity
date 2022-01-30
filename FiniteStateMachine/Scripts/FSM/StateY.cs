using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateY :BaseState
{
   public override void StateChanger(StateManager s){
       if(Input.GetKey(KeyCode.Y)){
           // do task 
            Debug.Log(  "pressed Y");
            s.StateChanger(s.sta);
            Debug.Log("state changed to a"); 
          
       }
    
      
   }
   
}
