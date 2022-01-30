using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateA : BaseState
{ 
  public override void StateChanger(StateManager s){
       if(Input.GetKey(KeyCode.A)){
           // do task 
            Debug.Log( "Pressed A");

           s.StateChanger(s.stb);
           Debug.Log("state changed to b");     
          }
      
   }
   
}
