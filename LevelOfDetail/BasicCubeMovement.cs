using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCubeMovement : MonoBehaviour
{
    public float speed=10f;
    float angularspeed=150f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,Input.GetAxis("Vertical")*Time.deltaTime*speed),Space.Self);
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(0,-angularspeed*Time.deltaTime,0,Space.Self);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(0,angularspeed*Time.deltaTime,0,Space.Self);
        }
    }
}
