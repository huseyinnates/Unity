using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControl : MonoBehaviour
{
   
    Rigidbody sphere;
    LayerMask lm;
    float rad=0.2f,forcespeed=50f;
    Transform camtransform;
    float horizontal,vertical;
    float speed=1f,mixrate=0.2f;
    Vector3 temp0,temp1;
    Vector3 offset=new Vector3(0,3,-7);
    PhotonView mineview;
    
    void Start()
    { 
        sphere=gameObject.GetComponent<Rigidbody>();
        lm=LayerMask.GetMask("wall");
        camtransform=GameObject.Find("MainCamera").GetComponent<Transform>();
        mineview=sphere.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

       
      if(mineview.IsMine){
          horizontal=Input.GetAxis("Horizontal");
      temp0=new Vector3(horizontal,0,0)*speed;
      vertical=Input.GetAxis("Vertical");
      temp1=new Vector3(0,0,vertical)*speed;

    sphere.AddForce(temp0);
    sphere.AddForce(temp1);
      }
    
    }
    void FixedUpdate(){
        if(mineview.IsMine){
            if(Input.GetKey(KeyCode.Space)){
             if(Physics.CheckSphere(sphere.position-new Vector3(0,1.2f,0),rad,lm)){
                 sphere.AddForce(Vector3.up*forcespeed,ForceMode.Force);  
   
            }
             Debug.Log(Physics.CheckSphere(sphere.transform.position-new Vector3(0,1f,0),rad,lm));
        }
        
        Vector3  pos1=sphere.GetComponent<Transform>().position+offset;
        Vector3 pos2=Vector3.Lerp(GameObject.Find("MainCamera").GetComponent<Transform>().position,sphere.GetComponent<Transform>().position+offset,mixrate);
        GameObject.Find("MainCamera").GetComponent<Transform>().position=pos2;
        }
        
    }
    void OnCollision(Collision col){
        if(col.gameObject.name=="yaxis"){
         Debug.Log("Wrong Place to visit");
        }
       
        
    }
    
}
