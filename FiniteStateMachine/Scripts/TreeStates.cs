using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeStates : MonoBehaviour
{
   public Animator transitions;
   MeshRenderer meshrend;
   Rigidbody rb;
   MeshCollider mc;
   public void Start(){
    rb=gameObject.GetComponent<Rigidbody>();
    mc=gameObject.GetComponent<MeshCollider>();
    meshrend=gameObject.GetComponent<MeshRenderer>();
   }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.T)){
         transitions.SetBool("SizeControl",true);
         meshrend.material.color=Color.gray;
        }
        if(Input.GetKey(KeyCode.R)){
            mc.enabled=true;
            rb.useGravity=true;
        }
        if(Input.GetKey(KeyCode.Y)){
            Destroy(this.gameObject);
        }
    }
}
