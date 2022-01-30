using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class StateT :BaseState
{
   public  override void StateChanger(StateManager s){
       if(Input.GetKey(KeyCode.T)){
           // do task 
            Debug.Log(  "pressed T");
            s.StateChanger(s.sty);
            Debug.Log("state changed to y");   
          
       }
   
      
   }
}
