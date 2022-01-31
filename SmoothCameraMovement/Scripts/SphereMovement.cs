using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public Rigidbody sphere;
    public GameObject cam,spawnpointf,spawnpoints,text,exclusive;
    Transform camtransform;
    float horizontal,vertical;
    public float speed=1f,mixrate=0.2f;
    Vector3 temp0,temp1;
    public Vector3 offset=new Vector3(0,3,3);
    int a=1;
    // Start is called before the first frame update
    void Start()
    { 
        camtransform=cam.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      horizontal=Input.GetAxis("Horizontal");
      temp0=new Vector3(horizontal,0,0)*speed;
      vertical=Input.GetAxis("Vertical");
      temp1=new Vector3(0,0,vertical)*speed;

    sphere.AddForce(temp0);
    sphere.AddForce(temp1);
    
    }
    void FixedUpdate(){
        Vector3  pos1=sphere.GetComponent<Transform>().position+offset;
        Vector3 pos2=Vector3.Lerp(cam.GetComponent<Transform>().position,sphere.GetComponent<Transform>().position+offset,mixrate);
        cam.GetComponent<Transform>().position=pos2;
        if(a==1 && sphere.position.z>230) {
            a=0;
            text.SetActive(true);
            exclusive.SetActive(true);
        }
        if(Input.GetKey(KeyCode.M)){
            exclusive.GetComponent<AudioSource>().enabled=false;
        }
        
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.name=="SpawnAgain"){
            if(sphere.position.z<390){
                sphere.position=spawnpointf.GetComponent<Transform>().position;
                sphere.velocity=new Vector3(0,0,0);
            }
            else{
                sphere.position=spawnpoints.GetComponent<Transform>().position;
                sphere.velocity=new Vector3(0,0,0);
            }
           
        }
        

    }
    
}
