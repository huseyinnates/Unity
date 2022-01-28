using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayForRange : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform rayorigin;
    public Transform hitpoint;
    public Vector3 direction=new Vector3(0,0,0);
    public Vector3 totargetspeed;
    public float sphereradius=0.14f,maneuverspeed=20f,forwardspeed=1f,tts=10f;
    Ray raystart,rayend;
    public Transform drone,targetpoint;
    RaycastHit hit;
    public Rigidbody rgbd;
    void Start()
    {
       hitpoint.position=transform.position;
    }
   void OnDrawGizmos(){
       Gizmos.DrawLine(transform.position,targetpoint.position);
       Gizmos.DrawSphere(rayorigin.position,sphereradius);
       Gizmos.DrawSphere(hitpoint.position,sphereradius);
       Gizmos.DrawLine(rayorigin.position,hitpoint.position);
   }

    // Update is called once per frame
    void FixedUpdate()
    {
        totargetspeed=targetpoint.position-transform.position;
        totargetspeed=totargetspeed.normalized;
        raystart=new Ray(rayorigin.position,Vector3.down);
        if(Physics.Raycast(raystart,out hit)){
            hitpoint.position=hit.point;
            Debug.Log(hit.point);
            float distance=Vector3.Distance(transform.position,hit.point);
            if(distance<5 ){
                Debug.Log("Go up");
                drone.position+=new Vector3(0,maneuverspeed*Time.deltaTime,0);
            }
            if(distance>15){
                Debug.Log("Go Down");
                drone.position+=new Vector3(0,-maneuverspeed*Time.deltaTime,0);
            }
            Debug.Log(Vector3.Distance(transform.position,hit.point));
            

        }
        if(Vector3.Distance(targetpoint.position,hitpoint.position)>10){
             rgbd.velocity=totargetspeed*tts;
        }else{
            rgbd.velocity=new Vector3(0,0,0);
        }
       
        
    }
}
