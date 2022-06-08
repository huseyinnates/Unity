using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreVibration : MonoBehaviour
{
   
   public void VibrateWithTime(){
       long a=0;
       Vibration.Vibrate(a);
       a+=50;
       if(a>1200){
           a=0;
       }
   }
   public void Vibrate_Pop(){
       Vibration.VibratePop();
   }
   public void Vibrate_Peek(){
       Vibration.VibratePeek();
   }
    public void Vibrate_Nope(){
       Vibration.VibrateNope();
   }
    public void Vibrate_Cancel(){
       
       Vibration.Cancel();
   }
   
}
