using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform fly;
    float horizontal,vertical;
    public float axisyspeed=10f,sens=10f;
    Vector3 temp;
    float rotx=0,roty=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal=Input.GetAxis("Horizontal");
        vertical=Input.GetAxis("Vertical");
    
        fly.localPosition+=fly.right*horizontal;
        fly.localPosition+=fly.forward*vertical;
        if(Input.GetKey(KeyCode.Q)){
               fly.localPosition+=new Vector3(0,axisyspeed*Time.deltaTime,0);
        }
        if(Input.GetKey(KeyCode.E)){
              fly.localPosition+=new Vector3(0,-axisyspeed*Time.deltaTime,0);
        }
        
        rotx += Input.GetAxis("Mouse X")* Time.deltaTime*sens;
		roty += Input.GetAxis("Mouse Y") * Time.deltaTime*sens;
		roty = Mathf.Clamp(roty, -90, 90);

		fly.localRotation = Quaternion.AngleAxis(rotx, Vector3.up);
		fly.localRotation*=Quaternion.AngleAxis(roty, Vector3.left);
    }
}
