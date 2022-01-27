using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Points{
    public Vector3 position;
    public Quaternion rotation;
}
public class TimeRewind : MonoBehaviour
{
    Vector3 holdLastPos;
    List<Points> points;
    public int savecount=301;
    Rigidbody rigid;
    void Start(){
        points=new List<Points>();
        rigid=gameObject.GetComponent<Rigidbody>();
    }
    
     void FixedUpdate(){
         if(Input.GetKey(KeyCode.UpArrow)){
             ReadInfo();
             Debug.Log("Pressed");
             rigid.useGravity=false;
             rigid.isKinematic=true;
         }else{
             SaveInfo();
             rigid.useGravity=true;
             rigid.isKinematic=false;
         }
       
     }    
     void ReadInfo(){
     

         if(points.Count>0){
             Points a=new Points();
             a=points[0];
             transform.position=a.position;
             transform.rotation=a.rotation;
             points.RemoveAt(0);
             
         }
         
     }
     
     void SaveInfo(){
      
         Points a=new Points();
         if(points.Count<savecount){
            a.position=transform.position;
            a.rotation=transform.rotation;
            points.Insert(0,a);
         }else{
            points.RemoveAt(points.Count-1);
            a.position=transform.position;
            a.rotation=transform.rotation;
            points.Insert(0,a);
            Debug.Log(points[0].position);

         }
     }
}
