using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTargetInstantiate : MonoBehaviour
{
    Ray screentoworld;
    public Camera cmr;
    public Transform target;
    RaycastHit world;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if(Input.GetButton("Fire1")){
            screentoworld=cmr.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(screentoworld,out world)){
                target.position=world.point;
            }
        }
    }
}
