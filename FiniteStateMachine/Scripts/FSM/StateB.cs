using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class StateB:BaseState
{
  public  override void StateChanger(StateManager s){
       if(Input.GetKey(KeyCode.B)){
           // do task 
            Debug.Log(  "Pressed B");
            s.StateChanger(s.str);
            Debug.Log("state changed to r");     
           
       }
  
      
   }

}
