using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager:MonoBehaviour
{
   //we can manage states only with checking the one if condition 
   //otherwise each time we should check 5 if
   //we used power of the superclass can reference subclass
   //that way we reference with same variable (currentstate)
    BaseState currentstate;  
    public StateA sta=new StateA();
    public StateB stb=new StateB();
    public StateR str=new StateR();
    public StateT stt=new StateT();
    public StateY sty=new StateY();
    void Start(){
        currentstate=sta;
        currentstate.StateChanger(this);
    }
    void Update(){
        currentstate.StateChanger(this);
    }

   public void StateChanger(BaseState state){
        currentstate=state;
    }

}
